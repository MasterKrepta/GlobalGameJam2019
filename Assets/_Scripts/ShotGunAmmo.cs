using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunAmmo : Ammo
{
 
        public Type type = Type.SHOTGUN;
        [SerializeField] int amount;

    public override void Pickup() {
        Inventory.instance.shotgunAmmo += amount;

    }
}
