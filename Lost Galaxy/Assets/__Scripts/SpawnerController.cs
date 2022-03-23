using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private List <WavesConfig> wavesConfigs;
    [SerializeField] private Quaternion spawnRotation;
    [SerializeField] private float initialStartTime;
    [SerializeField] private float cadenceBetweenWaves;

    private void Start()
    {
        GameController.Instance.OnEnemyDied += OnEnemyDied;

        StartCoroutine(EnemySpawnCoroutine());
    }

    private void OnEnemyDied(GameObject corps)
    {
        Debug.Log("Kill!");
    }

    private IEnumerator EnemySpawnCoroutine()
    {
        yield return new WaitForSeconds(initialStartTime);

        foreach (var wave in wavesConfigs)
        {
            foreach (var enemy in wave.enemies)
            {
                Vector3 enemyPosition = Vector3.zero;
                if (enemy.useSpecificXPosition)
                {
                    enemyPosition = enemy.spawnReferencePosition;
                }
                else
                {
                    enemyPosition = new Vector3(Random.Range(-enemy.spawnReferencePosition.x, enemy.spawnReferencePosition.x), enemy.spawnReferencePosition.y, 0);
                }

                SpawnEnemy(enemy.enemyPrefab, enemy.config, enemyPosition, spawnRotation);
                yield return new WaitForSeconds(wave.cadance);
            }

            yield return new WaitForSeconds(cadenceBetweenWaves);
        }
    }

    public void SpawnEnemy(EnemyController enemyPrefab, EnemyConfig config, Vector3 enemyPosition, Quaternion rotation)
    {
        var enemy = Instantiate(enemyPrefab, enemyPosition, rotation);
        enemy.config = config;

    }
}
