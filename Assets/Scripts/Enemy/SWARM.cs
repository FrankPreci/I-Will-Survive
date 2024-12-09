using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoguelikeEnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;         // Array for different enemy prefabs
    public GameObject Q_EnemyPrefab;
    public GameObject player;
    public Timer timer;
    public float initialSpawnInterval = 3f;   // Starting time between spawns
    public float difficultyMultiplier = 0.95f; // Adjust spawn rate over time
    public float minSpawnInterval = 0.5f;     // Minimum time between spawns
    private float screenWidth;
    private float screenHeight;
    private float nextSpawnTime;
    private int lastMinuteChecked = 0;
    public float spawnBuffer = 100f;     // Distance outside the player's view to spawn
    public float spawnDistanceAbove = 100f;
    void Start()
    {
        // Calculate screen boundaries based on camera
        screenWidth = Camera.main.aspect * Camera.main.orthographicSize;
        screenHeight = Camera.main.orthographicSize;
        player = GameObject.Find("Character-i");
        timer = FindObjectOfType<Timer>();
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
        int currentMinute = Mathf.FloorToInt(timer.ElapsedTime / 30);
        if (currentMinute > lastMinuteChecked)
        {
            SpawnEnemiesAbovePlayer();
            lastMinuteChecked = currentMinute;
        }

    }

    void SpawnRandomEnemyAtEdge()
    {
        // Pick a random enemy prefab
        GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        
        Vector2 spawnPosition = Vector2.zero;
        Vector2 cameraPosition = player.transform.position;

        // Randomly choose an edge to spawn the enemy
        int edge = Random.Range(0, 4);  // 0: left, 1: right, 2: top, 3: bottom
        switch (edge)
        {
            case 0: // Left
                spawnPosition = new Vector2(cameraPosition.x - screenWidth - spawnBuffer, Random.Range(cameraPosition.y - screenHeight, cameraPosition.y + screenHeight));
                break;
            case 1: // Right
                spawnPosition = new Vector2(cameraPosition.x + screenWidth + spawnBuffer, Random.Range(cameraPosition.y - screenHeight, cameraPosition.y + screenHeight));
                break;
            case 2: // Top
                spawnPosition = new Vector2(Random.Range(cameraPosition.x - screenWidth, cameraPosition.x + screenWidth), cameraPosition.y + screenHeight + spawnBuffer);
                break;
            case 3: // Bottom
                spawnPosition = new Vector2(Random.Range(cameraPosition.x - screenWidth, cameraPosition.x + screenWidth), cameraPosition.y - screenHeight - spawnBuffer);
                break;
        }

        // Instantiate the enemy at the spawn position
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
    void SpawnEnemiesAbovePlayer()
    {
        Vector3 playerPosition = player.transform.position;

        for (int i = 0; i < 2; i++) // Spawn two enemies
        {
            // Generate a random offset to vary spawn positions
            float randomOffset = Random.Range(-100f, 100f);

            // Calculate spawn position above the player
            Vector3 spawnPosition = new Vector3(
                playerPosition.x + randomOffset,
                playerPosition.y + spawnDistanceAbove,
                playerPosition.z
            );

            // Instantiate the timed enemy prefab
            Instantiate(Q_EnemyPrefab, spawnPosition, Quaternion.identity);
        }
    }

    void UpdateSpawnInterval()
    {
        // Decrease the spawn interval to make the game progressively harder
        initialSpawnInterval *= difficultyMultiplier;
        initialSpawnInterval = Mathf.Max(initialSpawnInterval, minSpawnInterval);
        nextSpawnTime = Time.time + initialSpawnInterval;
    }
}