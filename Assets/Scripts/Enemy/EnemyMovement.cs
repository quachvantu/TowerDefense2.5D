using System;
using System.IO;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public static event Action<int> OnEnemyReachedEnd;
    private Enemy enemy;
    private PathNode currentNode;
    private PathNode targetNode;
    [SerializeField] private float speed = 0.5f;
    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        if (targetNode == null)
        {
            OnEnemyReachedEnd?.Invoke(enemy.BaseDamage);
            Destroy(gameObject);
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, targetNode.transform.position, speed * Time.deltaTime);
        Vector3 direction = targetNode.transform.position - transform.position;
        direction.y = 0f;
        transform.rotation = Quaternion.LookRotation(direction);
        if (Vector3.Distance(transform.position, targetNode.transform.position) < 0.05f)
        {
            InitializePath(targetNode);
        }
    }
    public void InitializePath(PathNode startNode)
    {
        currentNode = startNode;
        targetNode = currentNode.GetNextNode();
    }
}
