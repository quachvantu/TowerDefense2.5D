using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyHealth Health { get; private set; }
    public EnemyMovement Movement { get; private set; }
    private void Awake()
    {
        Health = GetComponent<EnemyHealth>();
        Movement = GetComponent<EnemyMovement>();
    }
}
