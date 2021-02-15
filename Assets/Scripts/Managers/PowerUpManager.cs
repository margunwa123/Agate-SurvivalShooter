using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public int powerUpSpawnDelay = 10;
    public MonoBehaviour factory;
    private bool powerUpInitiated = false;
    IFactory Factory { get { return factory as IFactory; } }
    // Start is called before the first frame update
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("PowerUp") != null)
        {
            // only 1 powerup at a time
            return;
        }
        if(powerUpInitiated)
        {
            return;
        }
        else StartCoroutine(spawnPowerUp());
    }

    IEnumerator spawnPowerUp()
    {
        powerUpInitiated = true;
        yield return new WaitForSeconds(powerUpSpawnDelay);
        int randomPowerUp = Random.Range(0, 2);
        Factory.FactoryMethod(randomPowerUp);
        powerUpInitiated = false;
    }

}
