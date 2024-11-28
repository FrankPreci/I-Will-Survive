using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoguelikeEnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;         // Array for different enemy prefabs
    public GameObject player;
    public float initialSpawnInterval = 3f;   // Starting time between spawns
    public float difficultyMultiplier = 0.95f; // Adjust spawn rate over time
    public float minSpawnInterval = 0.5f;     // Minimum time between spawns
    private float screenWidth;
    private float screenHeight;
    private float nextSpawnTime;

    void Start()
    {
        // Calculate screen boundaries based on camera
        screenWidth = Camera.main.aspect * Camera.main.orthographicSize;
        screenHeight = Camera.main.orthographicSize;
        player = GameObject.Find("Character-i");
        nextSpawnTime = Time.time + initialSpawnInterval;
    }

    void Update()
    {
        if (!player.activeInHierarchy) { 
            this.gameObject.SetActive(false);
        }
        if (Time.time >= nextSpawnTime)
        {
            SpawnRandomEnemyAtEdge();
            UpdateSpawnInterval();
        }
    }

    void SpawnRandomEnemyAtEdge()
    {
        // Pick a random enemy prefab
        GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        
        Vector2 spawnPosition = Vector2.zero;

        // Randomly choose an edge to spawn the enemy
        int edge = Random.Range(0, 4);  // 0: left, 1: right, 2: top, 3: bottom
        switch (edge)
        {
            case 0: // Left
                spawnPosition = new Vector2(-screenWidth, Random.Range(-screenHeight, screenHeight));
                break;
            case 1: // Right
                spawnPosition = new Vector2(screenWidth, Random.Range(-screenHeight, screenHeight));
                break;
            case 2: // Top
                spawnPosition = new Vector2(Random.Range(-screenWidth, screenWidth), screenHeight);
                break;
            case 3: // Bottom
                spawnPosition = new Vector2(Random.Range(-screenWidth, screenWidth), -screenHeight);
                break;
        }

        // Instantiate the enemy at the spawn position
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    void UpdateSpawnInterval()
    {
        // Decrease the spawn interval to make the game progressively harder
        initialSpawnInterval *= difficultyMultiplier;
        initialSpawnInterval = Mathf.Max(initialSpawnInterval, minSpawnInterval);
        nextSpawnTime = Time.time + initialSpawnInterval;
    }
}