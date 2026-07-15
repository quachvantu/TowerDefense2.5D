using UnityEngine;

public class StraightBullet : Bullet
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float rotationSpeed;
    private void Update()
    {
        if (currentTarget == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 direction = currentTarget.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        direction.Normalize();
        transform.position += direction * bulletSpeed * Time.deltaTime;
    }
    public override void SetTarget(Enemy target, int damage)
    {
        base.SetTarget(target, damage);
    }
}
