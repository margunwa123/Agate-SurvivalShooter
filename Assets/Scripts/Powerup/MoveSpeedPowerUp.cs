using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeedPowerUp : PowerUp
{
    public int duration = 4;
    public float speedIncrease = 6;

    private PlayerMovement playerMovement;

    public override void Use(Collider player)
    {
        playerMovement= player.GetComponent<PlayerMovement>();
        playerMovement.addSpeed(speedIncrease);
        StartCoroutine(destroyAfterDuration());
    }

    IEnumerator destroyAfterDuration()
    {
        transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(duration);
        playerMovement.addSpeed(-speedIncrease);
        Destroy(gameObject);
    }
}
