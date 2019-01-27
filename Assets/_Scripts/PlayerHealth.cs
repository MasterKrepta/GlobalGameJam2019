using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] PlayerMovement playermove;
    [SerializeField] Shooting shooting;
    [SerializeField] GameObject shotgun;
    [SerializeField] GameObject soaker;
    [SerializeField] HeadBob headbob;


    public float currentHealth;
    public float currentArmor;

   public Enemy stats;
    private float invulTime = 2f;
    bool dead = false;
    [SerializeField] bool canTakeDamage = true;

    // Start is called before the first frame update
    void Start() {
        playermove = GetComponent<PlayerMovement>();
        shooting = GetComponent<Shooting>();
        headbob = FindObjectOfType<HeadBob>();
        currentArmor = 0f;
        currentHealth = stats.maxHealth;
        UpdateUi.UpdateStats();
       
    }

    private void Update() {
        if (dead) {
            if (Input.GetKeyDown(KeyCode.R)) {
                StartCoroutine(Restart());
             
                
            }
        }
        if (Input.GetKeyDown(KeyCode.G) && Input.GetKeyDown(KeyCode.M)) {
            Cheating();
        }
    }


    IEnumerator Restart() {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(1);
    }
    private void Cheating() {
        Debug.Log("CHEATS ENGAGED");
        currentArmor = 500;
        currentHealth = 1000;
        Inventory.instance.shotgunAmmo = 999;
        Inventory.instance.soakerAmmo = 999;
        UpdateUi.UpdateStats();


    }

    public void Die() {
        DisablePlayer();
        //TODO give points or spawn next one
    }

    public void TakeDamage(float dmg) {
        if (!dead) {
            SoundManager.instance.PlayClip(SoundManager.instance.playerHurt);
            if (canTakeDamage) {

                canTakeDamage = false;
                StartCoroutine(Invincibility());
                if (currentArmor > 0) {
                    currentArmor -= dmg;
                }
                else {
                    currentHealth -= dmg;
                }

                if (currentArmor < 0) {
                    currentArmor = 0;
                }
                UpdateUi.UpdateStats();
            }

            if (currentHealth <= 0) {
                SoundManager.instance.PlayClip(SoundManager.instance.playerDie);
                Die();
            }
        }
        
    }


    IEnumerator Invincibility() {
        yield return new WaitForSeconds(invulTime);
        canTakeDamage = true;
    }

 

    void DisablePlayer() {
        playermove.enabled = false;
        shotgun.SetActive(false);
        soaker.SetActive(false);
        shooting.enabled = false;
        headbob.enabled = false;
        dead = true;
      
    }
}
