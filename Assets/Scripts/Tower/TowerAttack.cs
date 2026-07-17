using System.Reflection;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    private TowerTargeting towerTargeting;
    [SerializeField] private int damage;
    [SerializeField] private float attackCooldown;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform[] firePoint;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject stoneVisual;
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
        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }
        else
        {
            SpawnBullet();
        }
    }
    private void SpawnBullet()
    {
        foreach (Transform point in firePoint)
        {
            GameObject bullet = Instantiate(bulletPrefab, point.position, point.rotation);
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.SetTarget(towerTargeting.GetCurrentTarget(), damage);
        }
    }
    public void ReleaseStone()
    {
        if (stoneVisual != null)
        {
            stoneVisual.SetActive(false);
        }
        SpawnBullet();
    }
    public void ReloadStone()
    {
        stoneVisual.SetActive(true);
    }
}
