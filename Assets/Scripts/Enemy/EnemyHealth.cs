using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    public int MaxHealth => maxHealth;
    public event Action OnHealthChanged;
    public int CurrentHealth { get; private set; }
    public event Action<Enemy> OnEnemyDied;
    private Enemy enemy;
    private void Awake()
    {
        CurrentHealth = maxHealth;
        enemy = GetComponent<Enemy>();
    }
    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        CurrentHealth = Mathf.Max(0, CurrentHealth - damage);
        OnHealthChanged?.Invoke();
        if (CurrentHealth <= 0)
        {
            OnEnemyDied?.Invoke(enemy);
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
