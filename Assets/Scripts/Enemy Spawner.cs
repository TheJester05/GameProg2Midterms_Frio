using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2.0f;
    public float spawnRadiusX = 15f;  // Radius for random X positions
    public float minZ = -10f;         // Minimum Z value for spawning
    public float maxZ = 10f;          // Maximum Z value for spawning

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1.0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        // Spawn enemies at random positions within the X and Z range
        Vector3 randomPosition = GetRandomSpawnPosition();
        Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
    }

    Vector3 GetRandomSpawnPosition()
    {
        // Choose a random position within a circle for X, and within defined min and max Z
        float randomX = Random.Range(-spawnRadiusX, spawnRadiusX);
        float randomZ = Random.Range(minZ, maxZ);
        return new Vector3(randomX, 0, randomZ);  // Adjust Y-axis if needed (depending on your game plane)
    }
}
