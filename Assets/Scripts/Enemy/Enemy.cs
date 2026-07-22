using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyHealth Health { get; private set; }
    public EnemyMovement Movement { get; private set; }
    [SerializeField] private int baseDamage;

    public int BaseDamage => baseDamage;
    private void Awake()
    {
        Health = GetComponent<EnemyHealth>();
        Movement = GetComponent<EnemyMovement>();
    }
}
