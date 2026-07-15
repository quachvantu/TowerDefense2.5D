using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected Enemy currentTarget;
    protected int currentDamage;
    public virtual void SetTarget(Enemy target, int damage)
    {
        currentDamage = damage;
        currentTarget = target;
    }
    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null && enemy == currentTarget)
        {
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(currentDamage);
            Destroy(gameObject);
        }
    }
}
