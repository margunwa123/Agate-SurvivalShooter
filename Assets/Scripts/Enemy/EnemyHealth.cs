using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;

    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;


    void Awake ()
    {
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();

        currentHealth = startingHealth;
    }


    void Update ()
    {
        if (isSinking)
        {
            // pindahin object kebawah
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        Debug.Log("aw kena hit!");
        if (isDead)
            return;

        // misal take damage, play audio
        enemyAudio.Play ();

        currentHealth -= amount;

        // posisi partikel dia ke hit
        hitParticles.transform.position = hitPoint;
        // mainin animasi kalo dia ke hit (partikel melayang)
        hitParticles.Play();

        if (currentHealth <= 0)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;
        ScoreManager.score += scoreValue;
        // maenin animasii dead
        anim.SetTrigger ("Dead");

        // maenin audio dead
        enemyAudio.clip = deathClip;
        enemyAudio.Play ();
    }


    public void StartSinking ()
    {
        // disable navmesh
        GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled = false;
        // set rigidbody ke kinematic (jadinya ga dipengaruhi gaya (?))
        GetComponent<Rigidbody> ().isKinematic = true;
        isSinking = true;
        // jatoh ke bawah ( animasi kekubur )
        //ScoreManager.score += scoreValue;
        Destroy (gameObject, 2f);
    }
}
