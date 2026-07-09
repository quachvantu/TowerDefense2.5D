using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<EnemyMovement> enemyPrefabs;
    [SerializeField] private PathNode spawnPoint;
    [SerializeField] private float spawnInterval;
    private void SpawnEnemy()
    {
        EnemyMovement enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)], spawnPoint.transform.position, Quaternion.identity);
        enemy.InitializePath(spawnPoint);
    }
    private IEnumerator SpawnRoutine(int enemyCount)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    public IEnumerator SpawnWave(int enemyCount)
    {
        yield return SpawnRoutine(enemyCount);
    }
}