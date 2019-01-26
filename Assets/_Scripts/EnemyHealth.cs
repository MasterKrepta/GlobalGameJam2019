using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField]Enemy stats;

    [SerializeField]float currentHealth;

    private float flashTime = .2f;
    [SerializeField] Color original;
    [SerializeField] Color HitColor = Color.red;
    // Start is called before the first frame update
    void Start() {
        original = GetComponentInChildren<Renderer>().material.color;
        currentHealth = stats.maxHealth;
    }


    public void Die() {
        Destroy(this.gameObject);
        //TODO give points or spawn next one
    }

    public void TakeDamage(float dmg) {
        StartCoroutine(Flash());
        currentHealth--;
        if (currentHealth<= 0) {
            Die();
        }
    }



    IEnumerator Flash() {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers) {
            r.material.color = HitColor;
        }
       
        yield return new WaitForSeconds(flashTime);
        foreach (Renderer r in renderers) {
            if (r != null) {
                r.material.color = original;
            }
        }
    }
}
