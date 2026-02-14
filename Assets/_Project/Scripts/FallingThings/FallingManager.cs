using UnityEngine;

public class FallingManager : MonoBehaviour
{
    [SerializeField] private GameObject[] fallingObjs;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float minSpawnInterval = 0.5f;
    [SerializeField] private float spawnIntervalDecrease = 0.1f;
    [SerializeField] private float spawnXRange = 8f;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnFallingObject();
            timer = 0f;
            // Diminuisci l'intervallo di spawn fino al minimo
            if (spawnInterval > minSpawnInterval)
            {
                spawnInterval -= spawnIntervalDecrease;
                spawnInterval = Mathf.Max(spawnInterval, minSpawnInterval);
            }
        }
    }

    private void SpawnFallingObject()
    {
        if (fallingObjs.Length == 0) return;

        int index = Random.Range(0, fallingObjs.Length);
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnXRange, spawnXRange), transform.position.y, transform.position.z);
        Instantiate(fallingObjs[index], spawnPosition, Quaternion.identity);
    }
}