using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyHealth Health { get; private set; }
    public EnemyMovement Movement { get; private set; }
    [SerializeField] private int baseDamage;
    [SerializeField] private int goldReward;
    public int BaseDamage => baseDamage;
    public int GoldReward => goldReward;
    private void Awake()
    {
        Health = GetComponent<EnemyHealth>();
        Movement = GetComponent<EnemyMovement>();
    }
}
