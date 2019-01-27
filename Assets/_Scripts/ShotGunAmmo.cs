using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunAmmo : Ammo
{
 
        public Type type = Type.SHOTGUN;
        [SerializeField] int amount;

    public override void Pickup() {
        Debug.Log(this.gameObject.name + " has been picked up");
        Inventory.instance.shotgunAmmo += amount;

    }

    //private void OnTriggerEnter(Collider other) {
    //    Debug.Log(other.name);
    //    PlayerHealth h = other.GetComponent<PlayerHealth>();
    //    if (h != null) {
    //        Pickup();
    //        UpdateUi.UpdateStats();
    //    }
    //}
}
