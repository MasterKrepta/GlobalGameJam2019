using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public float currentHealth;
    public float currentArmor;

   public Enemy stats;
    private float invulTime = 2f;

    [SerializeField] bool canTakeDamage = true;

    // Start is called before the first frame update
    void Start() {
        currentArmor = 0f;
        currentHealth = stats.maxHealth;
        UpdateUi.UpdateStats();
    }


    public void Die() {
        this.gameObject.SetActive(false);
        //TODO give points or spawn next one
    }

    public void TakeDamage(float dmg) {
   
        if (canTakeDamage) {

            canTakeDamage = false;
            StartCoroutine(Invincibility());
            if (currentArmor > 0) {
                currentArmor -=dmg;
            }
            else {
                currentHealth -= dmg;
            }
            UpdateUi.UpdateStats();
        }
       
        if (currentHealth <= 0) {
            Die();
        }
    }


    IEnumerator Invincibility() {
        yield return new WaitForSeconds(invulTime);
        canTakeDamage = true;
    }

    private void OnTriggerEnter(Collider other) {
        if (true) {

        }
    }
}
