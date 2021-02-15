using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    SphereCollider sphereCollider;

    public int PowerUpDuration = 5;

    public abstract void Use(Collider player);

    public void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" || other.isTrigger) return;
        // destroy the sphere collider so it cant collide again
        Destroy(sphereCollider);
        // use the power up
        Use(other);
    }
}
