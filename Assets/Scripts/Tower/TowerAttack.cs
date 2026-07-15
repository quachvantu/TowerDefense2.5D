using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    private TowerTargeting towerTargeting;
    [SerializeField] private int damage;
    [SerializeField] private float attackCooldown;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform[] firePoint;
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
            SpawnBullet();
            attackTimer = 0f;
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
}
