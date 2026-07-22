using System;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    public int CurrentHealth { get; private set; }
    private void OnEnable()
    {
        EnemyMovement.OnEnemyReachedEnd += HandleEnemyReachedEnd;
    }
    private void OnDisable()
    {
        EnemyMovement.OnEnemyReachedEnd -= HandleEnemyReachedEnd;
    }
    private void HandleEnemyReachedEnd(int damage)
    {
        TakeDamage(damage);
    }
    private void Start()
    {
        CurrentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, maxHealth);
        Debug.Log(CurrentHealth);
        if (CurrentHealth == 0)
        {
            Debug.Log("Game Over");
        }
    }
}
