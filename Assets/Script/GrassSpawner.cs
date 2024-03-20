using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSpawner : MonoBehaviour
{
    public GameObject grassPrefab;
    public float spawnInterval = 5f;
    public int mapWidth = 20;
    public int mapHeight = 20;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnGrass), spawnInterval, spawnInterval);
    }

    void SpawnGrass()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(-mapWidth / 2, mapWidth / 2), Random.Range(-mapHeight / 2, mapHeight / 2));
        Instantiate(grassPrefab, spawnPosition, Quaternion.identity);
    }
}

