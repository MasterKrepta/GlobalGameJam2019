using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauseDamage : MonoBehaviour
{
    [SerializeField] float damageAmount = 1;


    private void OnTriggerEnter(Collider other) {
        IDamageable hitObj = other.GetComponent<IDamageable>();
        if (hitObj != null) {
            hitObj.TakeDamage(damageAmount);
            Destroy(this.gameObject);
        }
    }
}
