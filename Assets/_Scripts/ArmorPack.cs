using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPack : Ammo
{
    PlayerHealth player;
    public Type type = Type.ARMOR;
    [SerializeField] int amount;

    private void Start() {
        player = FindObjectOfType<PlayerHealth>();
    }
    public override void Pickup() {
        Debug.Log(this.gameObject.name + " has been picked up");
        if (player.currentArmor != player.stats.maxArmor) {
            player.currentArmor += amount;
            if (player.currentArmor > player.stats.maxArmor) {
                player.currentArmor = player.stats.maxArmor;
            }
            Destroy(this.gameObject);
        }
     
        
    }
    //private void OnTriggerEnter(Collider other) {
    //    PlayerHealth h = other.GetComponent<PlayerHealth>();
    //    if (h != null) {
    //            Pickup();
    //        UpdateUi.UpdateStats();
    //    }
    //}
}
