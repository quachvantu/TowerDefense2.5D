using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    private TowerTargeting towerTargeting;
    [SerializeField] private int damage;
    [SerializeField] private float attackCooldown;
    private float attackTimer = 0f;
    private void Awake()
    {
        towerTargeting = GetComponent<TowerTargeting>();
    }
    private void Update()
    {
        if (towerTargeting.GetCurrentTarget() == null)
        {
            return;
        }
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackCooldown)
        {
            Attack();
            attackTimer = 0f;
        }
    }
    private void Attack()
    {
        Enemy target = towerTargeting.GetCurrentTarget();
        target.Health.TakeDamage(damage);
        Debug.Log(target.name);
    }
}
