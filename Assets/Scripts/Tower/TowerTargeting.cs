using System;
using System.Collections.Generic;
using UnityEngine;

public class TowerTargeting : MonoBehaviour
{
    private List<Enemy> enemiesInRange = new();
    private Enemy currentTarget;
    private void TowerTargeting_OnEnemyDied(EnemyHealth health)
    {
        Enemy enemy = health.GetComponent<Enemy>();
        RemoveEnemy(enemy);
    }
    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Health.OnEnemyDied += TowerTargeting_OnEnemyDied;
            AddEnemy(enemy);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Health.OnEnemyDied -= TowerTargeting_OnEnemyDied;
            RemoveEnemy(enemy);
        }
    }
    private void AddEnemy(Enemy enemy)
    {
        if (!enemiesInRange.Contains(enemy))
        {
            enemiesInRange.Add(enemy);
            UpdateTarget();
        }
    }
    private void RemoveEnemy(Enemy enemy)
    {
        enemiesInRange.Remove(enemy);
        UpdateTarget();
    }
    private void UpdateTarget()
    {
        if (enemiesInRange.Count == 0)
        {
            currentTarget = null;
            return;
        }
        currentTarget = enemiesInRange[0];
        float minDistance = Vector3.Distance(currentTarget.transform.position, transform.position);
        foreach (Enemy enemy in enemiesInRange)
        {
            float distance = Vector3.Distance(enemy.transform.position, transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                currentTarget = enemy;
            }
        }
    }
    public Enemy GetCurrentTarget()
    {
        return currentTarget;
    }
}
