using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ammo : MonoBehaviour
{
    public enum Type { SHOTGUN, SOAKER, ARMOR, HEALTH };

    public virtual void Pickup() { }
}

 

