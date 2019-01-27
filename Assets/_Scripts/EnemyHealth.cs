using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField]Enemy stats;
    [SerializeField] List<Transform> spawnables = new List<Transform>();

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
        ChanceForLoot();
        Destroy(this.gameObject);
        //TODO give points or spawn next one
    }

    private void ChanceForLoot() {
        //System.Random rnd = new System.Random;
        //int val = rnd.Next(1, 10);
        //if (val < 3) {
        //    Instantiate(spawnables[UnityEngine.Random.Range(0, spawnables.Count - 1)], transform.position, Quaternion.identity);
        //    Debug.Log("we spawned loot");
        //    //10% probabilty of coming to this block
        //    //Spawn an object which has 10% probability
        //    //1/10 = 0.1
        //}
        //else if (val < 6) {
        //    //50% probabilty
        //    // 1/10 + 1/10 + 1/10 + 1/10 + 1/10 + 1/10 = 5/10 = 0.5
        //}
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
