using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;


    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;


    void Awake ()
    {
        // cari game object dengan tag "Player"
        player = GameObject.FindGameObjectWithTag ("Player");

        // dapetin komponen player health
        playerHealth = player.GetComponent <PlayerHealth> ();

        // dapetin component animator
        anim = GetComponent <Animator> ();
        
        // dapetin komponen darah
        enemyHealth = GetComponent<EnemyHealth>();
    }

    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player && other.isTrigger == false)
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    void Update ()
    {
        timer += Time.deltaTime;

        // delay between attack and there is a player in range
        if(timer >= timeBetweenAttacks && playerInRange/* && enemyHealth.currentHealth > 0*/)
        {
            Debug.Log("Attack!");
            Attack ();
        }

        // trigger self animation
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger ("PlayerDead");
        }
    }


    void Attack ()
    {
        // reset attack timer
        timer = 0f;

        // Taking damage
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage (attackDamage);
        }
    }
}
