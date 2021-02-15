using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour, IFactory
{
    [SerializeField]
    public GameObject[] enemyPrefab;
    [SerializeField]
    public Transform[] spawnPoints;

    public GameObject FactoryMethod(int tag)
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        GameObject enemy = Instantiate(enemyPrefab[tag], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        return enemy;
    }
}
