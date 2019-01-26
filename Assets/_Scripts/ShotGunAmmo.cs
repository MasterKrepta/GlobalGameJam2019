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
        Destroy(this.gameObject);
    }
}
