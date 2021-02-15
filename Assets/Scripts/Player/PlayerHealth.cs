using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);


    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    //PlayerShooting playerShooting;
    bool isDead;                                                
    bool damaged;                                               


    void Awake()
    {
        // Mendapatkan reference komponen
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();

        //playerShooting = GetComponentInChildren<PlayerShooting>();
        currentHealth = startingHealth;
    }


    void Update()
    {
        if (damaged)
        {
            // ubah warna jadi value dari flashcolor
            damageImage.color = flashColour;
        }
        else
        {
            //Fade out damage image
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        // set image to false
        damaged = false;
    }

    //fungsi untuk mendapatkan damage
    public void TakeDamage(int amount)
    {
        damaged = true;

        // mengurangi health
        currentHealth -= amount;

        // ganti health sesuai currenthealth
        healthSlider.value = currentHealth;

        //memainkan suara hurt lol
        playerAudio.Play();

        //memanggil method death() jika darahnya <= 0 dan belom mati
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    public void heal(int healAmount)
    {
        if (isDead) return;
        if(currentHealth + healAmount > startingHealth)
        {
            currentHealth = startingHealth;
            // ganti health sesuai currenthealth
            healthSlider.value = currentHealth;
        }
        else
        {
            currentHealth += healAmount;
            // ganti health sesuai currenthealth
            healthSlider.value = currentHealth;
        }

    }

    void Death()
    {
        isDead = true;

        //playerShooting.DisableEffects();

        // trigger animation die
        anim.SetTrigger("Die");

        // mainin suara pas mati
        playerAudio.clip = deathClip;
        playerAudio.Play();

        // mainin script player movement
        playerMovement.enabled = false;

        //playerShooting.enabled = false;
    }

    public void RestartLevel()
    {
        //load ulang scene dengan index 0 pada build setting
        SceneManager.LoadScene(0);
    }
}
