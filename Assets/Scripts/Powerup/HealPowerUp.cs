using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPowerUp : PowerUp
{
    public int healingPower = 20;

    public override void Use(Collider player)
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        playerHealth.heal(healingPower);
        Destroy(gameObject);
    }
}
