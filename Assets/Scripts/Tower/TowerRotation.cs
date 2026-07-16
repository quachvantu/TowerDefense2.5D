using UnityEngine;

public class TowerRotation : MonoBehaviour
{
    [SerializeField] private Transform rotationTransform;
    [SerializeField] private bool rotateVertically;
    private TowerTargeting towerTargeting;
    private void Awake()
    {
        towerTargeting = GetComponent<TowerTargeting>();
    }
    private void Update()
    {
        Enemy target = towerTargeting.GetCurrentTarget();
        if (target == null)
        {
            return;
        }
        Vector3 positionWeapon = rotationTransform.position;
        Vector3 positionEnemy = target.transform.position;
        Vector3 direction = (positionEnemy - positionWeapon);
        if (!rotateVertically)
        {
            direction.y = 0f;
        }
        Quaternion quaternion = Quaternion.LookRotation(direction);
        float rotationSpeed = 10f;
        rotationTransform.rotation = Quaternion.Lerp(rotationTransform.rotation, quaternion, Time.deltaTime * rotationSpeed);
    }
}
