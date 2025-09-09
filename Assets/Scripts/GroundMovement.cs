using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GroundMovement : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private Tile ground;
    [SerializeField] private float movementSpeed = -2.0f;
    private int maxGroundItems = 10;
    private int groundHorizontalSpace = 9;
    private int groundPosition = -5;
    private int cycleRatio = 1;
    private int cycle = 40;

    // Update is called once per frame
    void Update()
    {
        generateGround();
        transform.position = new Vector3(transform.position.x + movementSpeed * Time.deltaTime, 0, 0);
    }

    private void generateGround()
    {
        if (tilemap != null & maxGroundItems >= 0)
        {
            tilemap.SetTile(new Vector3Int(groundPosition, -7, 0), ground);
            groundPosition += groundHorizontalSpace;
            --maxGroundItems;
        }
        if (canContinueGenerateGround(cycle))
        {
            maxGroundItems = 10;
            ++cycleRatio;
        }
    }

    private bool canContinueGenerateGround(int c)
    {
        if (transform.position.x <= -c * cycleRatio)
        {
            return true;
        }
        return false;
    }
}
