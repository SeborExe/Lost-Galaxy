using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Vector3 spawnReferencePosition;
    public Quaternion spawnRotation;
    public int amountEnemyToSpawn;
    public float spawnCadence;
    public float initialStartTime;

    private void Start()
    {
        StartCoroutine(EnemySpawnCoroutine());
    }

    private IEnumerator EnemySpawnCoroutine()
    {
        yield return new WaitForSeconds(initialStartTime);
        for (int i = 0; i < amountEnemyToSpawn; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-spawnReferencePosition.x, spawnReferencePosition.x), spawnReferencePosition.y, 0);
            SpawnEnemy(randomPosition, spawnRotation);
            yield return new WaitForSeconds(spawnCadence);
        }
    }

    public void SpawnEnemy(Vector3 enemyPosition, Quaternion rotation)
    {
        Instantiate(enemyPrefab, enemyPosition, rotation);
    }
}
