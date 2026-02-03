using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private float spawnInterval = 3f;

    [SerializeField] private float spawnRangeX = 8f;

    private float _lastSpawnTime;
    private void Update()
    {
        _lastSpawnTime += Time.deltaTime;
        if (_lastSpawnTime > spawnInterval)
        {
            Debug.Log("Attempting to spawn enemy...");
            _lastSpawnTime = 0f;
            TrySpawnEnemy();
        }
    }

    private void TrySpawnEnemy()
    {
        float spawnX = Random.Range(-spawnRangeX, spawnRangeX);

        foreach (GameObject enemyPrefab in enemyPrefabs)
        {

            int chance = Random.Range(0, 101);
            Debug.Log($"Spawn Chance Roll: {chance} for Enemy: {enemyPrefab.name} with Spawn Chance: {enemyPrefab.GetComponent<EnemyLogic>()?.EnemyData?.spawnChance}");
            if (chance <= enemyPrefab.GetComponent<EnemyLogic>()?.EnemyData?.spawnChance)
            {
                Debug.Log("Spawning Enemy: " + enemyPrefab.name);
                Instantiate(enemyPrefab, new Vector3(spawnX, transform.position.y, transform.position.z), Quaternion.identity);
                return;
            }
        }
    }
}