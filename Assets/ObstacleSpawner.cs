using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;  // Reference to the obstacle prefab
    public float minSpawnInterval = 0.2f; // Minimum time between spawns
    public float maxSpawnInterval = 0.7f; // Maximum time between spawns
    public float obstacleSpeed = 10f;  // Speed of obstacles moving down
    public float destroyYPosition = -6f;  // Position where obstacles are destroyed

    private readonly float[] lanes = { -3f, 0f, 3f };  // X positions of the lanes

    void Start()
    {
        // Start the spawning coroutine
        StartCoroutine(SpawnObstacles());
    }

    System.Collections.IEnumerator SpawnObstacles()
    {
        while (true)
        {
            // Generate a random spawn interval between minSpawnInterval and maxSpawnInterval
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);

            // Select a random lane for the obstacle
            float randomLane = lanes[Random.Range(0, lanes.Length)];
            Vector3 spawnPosition = new Vector3(randomLane, transform.position.y, 0f);

            // Instantiate the obstacle
            GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

            // Pass the speed and destroy position to the obstacle script
            Obstacle obstacleScript = obstacle.GetComponent<Obstacle>();
            obstacleScript.Initialize(obstacleSpeed, destroyYPosition);

            // Wait for the next spawn
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}

