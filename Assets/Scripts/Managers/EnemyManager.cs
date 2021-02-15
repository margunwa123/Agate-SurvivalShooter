using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float spawnTime = 3f;
    public MonoBehaviour factory;
    IFactory Factory { get { return factory as IFactory; } }


    void Start ()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn ()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }
        int spawnedEnemy = Random.Range(0, 3);

        Factory.FactoryMethod(spawnedEnemy);
    }
}
