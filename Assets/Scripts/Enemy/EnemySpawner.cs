using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Enemy> enemyPrefabs;
    [SerializeField] private PathNode spawnPoint;
    [SerializeField] private float spawnInterval;
    [SerializeField] private GoldManager goldManager;
    private void SpawnEnemy()
    {
        Enemy enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)], spawnPoint.transform.position, Quaternion.identity);
        enemy.Movement.InitializePath(spawnPoint);
        enemy.Health.OnEnemyDied += HandleEnemyDied;
    }

    private void HandleEnemyDied(Enemy enemy)
    {
        goldManager.AddGold(enemy.GoldReward);
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