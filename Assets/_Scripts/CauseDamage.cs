using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauseDamage : MonoBehaviour
{
    [SerializeField] float damageAmount = 1;


    private void OnTriggerEnter(Collider other) {
        IDamageable hitObj = other.GetComponent<IDamageable>();
        if (hitObj != null) {
            Debug.Log(other.name + " - takes damage from - " + this.gameObject);
            hitObj.TakeDamage(damageAmount);
            Destroy(this.gameObject);
            UpdateUi.UpdateStats();
        }
    }
}
