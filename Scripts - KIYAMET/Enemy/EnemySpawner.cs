using UnityEngine;

public class EnemySpawner : MonoBehaviour //how the enemies spawn near you.
{
    public GameObject enemyPrefab; // Reference to the enemy prefab to spawn
    public EnemyManager enemyManager; // Reference to the enemy manager
    public GameObject gunHitEffectPrefab; // Reference to the gun hit effect prefab
    public float spawnInterval = 3f; // Interval between enemy spawns
    public int maxEnemies = 10; // Maximum number of enemies to spawn

    private int currentEnemies = 0; // Current number of spawned enemies
    private float timer = 0f; // Timer to track spawn intervals

    void Update()
    {
        if (currentEnemies < maxEnemies)
        {
            timer += Time.deltaTime; // Increment the timer

            if (timer >= spawnInterval)
            {
                SpawnEnemy(); // Spawn an enemy
                timer = 0f; // Reset the timer
            }
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefab != null && enemyManager != null && gunHitEffectPrefab != null)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            Enemy enemyScript = newEnemy.GetComponent<Enemy>(); // Corrected line to get Enemy component
            enemyScript.enemyManager = enemyManager; // Assign the enemy manager to the enemy script
            enemyScript.gunHitEffect = gunHitEffectPrefab; // Assign the gun hit effect prefab to the enemy script
            currentEnemies++;
        }
    }

    public void DecreaseEnemyCount()
    {
        currentEnemies--;
    }
}
