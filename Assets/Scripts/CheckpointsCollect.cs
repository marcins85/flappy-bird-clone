using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointsCollect : MonoBehaviour
{
    [SerializeField] private Text pointsText;
    [SerializeField] private Text recordPointsText;
    [SerializeField] private AudioSource pointSound;
    private string saveFilename = null;
    private int points = 0;
    private int recordPoints = 0;

    private void Awake()
    {
        saveFilename = Application.persistentDataPath + "record.txt";
        if (File.Exists(saveFilename))
        {
            var fileContent = File.ReadAllText(saveFilename);
            recordPoints = Int32.Parse(fileContent);
            recordPointsText.text = recordPoints.ToString();
        }
    }
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {   
            pointSound.Play();
            pointsText.text = "" + ++points;
            if (recordPoints < points)
            {
                File.WriteAllText(saveFilename, points.ToString());
            }
        }
    }
}
