using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthpack : Ammo
{
    PlayerHealth player;
    public Type type = Type.HEALTH;
    [SerializeField] int amount;

    private void Start() {
        player = FindObjectOfType<PlayerHealth>();
    }
    public override void Pickup() {
           Debug.Log(this.gameObject.name + " has been picked up");
        //if (player.currentHealth != player.stats.maxHealth) {

            player.currentHealth += amount;
            if (player.currentHealth > player.stats.maxHealth) {
                player.currentHealth = player.stats.maxHealth;
            }
            Destroy(this.gameObject);
        //}
       
    }
    //private void OnTriggerEnter(Collider other) {
    //    PlayerHealth h = other.GetComponent<PlayerHealth>();
    //    if (h != null) {
    //        Pickup();
    //        UpdateUi.UpdateStats();
    //    }
    //}
}
