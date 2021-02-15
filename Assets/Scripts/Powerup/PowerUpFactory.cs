using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFactory : MonoBehaviour, IFactory
{
    [SerializeField]
    public GameObject[] powerUpPrefab;
    [SerializeField]
    public Transform[] spawnPoints;

    public GameObject FactoryMethod(int tag)
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        GameObject powerUp = Instantiate(powerUpPrefab[tag], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        return powerUp;
    }
}
