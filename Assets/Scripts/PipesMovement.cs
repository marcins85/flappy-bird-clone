using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class PipesMovement : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private Tilemap tilemapCheckpoint;
    [SerializeField] private Tile tileDown;
    [SerializeField] private Tile tileUp;
    [SerializeField] private Tile tileCheckpoint;
    [SerializeField] private float movementSpeed = -2.0f;
    private const int itemsCount = 5;
    private int maxPipeItems = itemsCount;
    private int pipeHorizontalSpace = 5;
    private int pipeVerticalSpace = 13;
    private int pipePosition = 5;
    private int cycleRatio = 1;
    private int cycle = 10;

    void Update()
    {
        transform.position = new Vector3(transform.position.x + movementSpeed * Time.deltaTime, 0, 0);
        tilemapCheckpoint.transform.position = transform.position;
        generatePipes();
    }

    private void generatePipes()
    {
        if (tilemap != null & maxPipeItems > 0)
        {
            var pipeDownRandomPosition = UnityEngine.Random.Range(-8, -4);
            var pipeUpRandomPosition = UnityEngine.Random.Range(2, 10);
            if (pipeUpRandomPosition - pipeDownRandomPosition >= pipeVerticalSpace)
            {
                tilemap.SetTile(new Vector3Int(pipePosition, pipeUpRandomPosition, 0), tileUp);
                tilemap.SetTile(new Vector3Int(pipePosition, pipeDownRandomPosition, 0), tileDown);
                tilemapCheckpoint.SetTile(new Vector3Int(pipePosition, 0, 0), tileCheckpoint);
                pipePosition += pipeHorizontalSpace;
                --maxPipeItems;
            }

        }
        if (canContinueGeneratePipes(cycle))
        {
            maxPipeItems = itemsCount;
            cycleRatio++;
        }
    }

    private bool canContinueGeneratePipes(int c)
    {
        if (transform.position.x < -c * cycleRatio)
        {
            return true;
        }
        return false;
    }
}
