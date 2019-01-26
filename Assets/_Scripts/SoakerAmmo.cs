using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoakerAmmo : Ammo
    {
        public Type type = Type.SOAKER;
        [SerializeField] int amount;


    public override void Pickup() {
        Debug.Log(this.gameObject.name + " has been picked up");
        Inventory.instance.soakerAmmo += amount;
        Destroy(this.gameObject);
    }
}

