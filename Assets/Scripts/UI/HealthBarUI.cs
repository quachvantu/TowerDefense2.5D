using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Image image;
    private EnemyHealth enemyHealth;
    private void Awake()
    {
        enemyHealth = GetComponentInParent<EnemyHealth>();
    }
    private void OnEnable()
    {
        enemyHealth.OnHealthChanged += UpdateHealthBarUI;
    }
    private void OnDisable()
    {
        enemyHealth.OnHealthChanged -= UpdateHealthBarUI;
    }
    private void UpdateHealthBarUI()
    {
        image.fillAmount = (float)enemyHealth.CurrentHealth / enemyHealth.MaxHealth;
    }
}
