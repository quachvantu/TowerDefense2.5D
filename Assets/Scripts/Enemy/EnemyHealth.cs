using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    public int MaxHealth => maxHealth;
    public event Action OnHealthChanged;
    public int CurrentHealth { get; private set; }
    public event Action<EnemyHealth> OnEnemyDied;
    private void Awake()
    {
        CurrentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        CurrentHealth = Mathf.Max(0, CurrentHealth - damage);
        OnHealthChanged?.Invoke();
        if (CurrentHealth <= 0)
        {
            OnEnemyDied?.Invoke(this);
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
