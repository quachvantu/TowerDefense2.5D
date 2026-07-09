using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private List<Wave> waves;
    private void Start()
    {
        StartCoroutine(WaveRoutine());
    }

    private IEnumerator WaveRoutine()
    {
        foreach (Wave wave in waves)
        {
            yield return enemySpawner.SpawnWave(wave.enemyCount);
            yield return new WaitForSeconds(wave.delayBeforeNextWave);
        }
    }
}
