using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoakerAmmo : Ammo
    {
        public Type type = Type.SOAKER;
        [SerializeField] int amount;


    public override void Pickup() {
        Inventory.instance.soakerAmmo += amount;

    }
}

