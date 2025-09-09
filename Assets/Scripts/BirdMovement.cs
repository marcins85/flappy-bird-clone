using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private AudioSource swooshSound;

    [SerializeField] private float jumpForce = 4;
    enum AnimationState { idle, jump, fall };

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    
    private void Update()
    {
        //BirdJump();
        BirdAnimation();
    }

    private void BirdJump()
    {
        //Touch touch = Input.GetTouch(0);
        if (Input.GetButtonDown("Jump"))// || touch.tapCount == 1)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            swooshSound.Play();
        }
    }

    public void OnFire(InputValue value)
    {
        //rb.AddForce(Vector2.up * jumpForce);
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        swooshSound.Play();
    }

    private void BirdAnimation()
    {
        AnimationState state;
        if (rb.linearVelocity.y > .1f)
        {
            state = AnimationState.jump;
            transform.rotation = Quaternion.Euler(0, 0, 4f);
        } else if (rb.linearVelocity.y < .1f)
        {
            state = AnimationState.fall;
            transform.rotation = Quaternion.Euler(0, 0, -4f);
        } else
        {
            state = AnimationState.idle;
        }

        anim.SetInteger("state", (int)state);
    }
}
