using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ArcBullet : Bullet
{
    [SerializeField] private float arcHeight = 3f;
    [SerializeField] private float bulletSpeed;
    private Vector3 targetPosition;
    private Vector3 startPosition;
    private float totalDistance;
    private float progress;
    public override void SetTarget(Enemy target, int damage)
    {
        base.SetTarget(target, damage);
        startPosition = transform.position;
        targetPosition = currentTarget.GetComponent<Transform>().position;
        totalDistance = Vector3.Distance(startPosition, targetPosition);
    }
    private void Update()
    {
        // if (currentTarget == null)
        // {
        //     Destroy(gameObject);
        //     return;
        // }
        progress += (bulletSpeed / totalDistance) * Time.deltaTime;
        progress = Mathf.Clamp01(progress);
        float height = Mathf.Sin(progress * Mathf.PI) * arcHeight;
        transform.position = Vector3.Lerp(startPosition, targetPosition, progress) + Vector3.up * height;
        if (progress >= 1f)
        {
            Destroy(gameObject);
            return;
        }

    }
}
