using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ammo : MonoBehaviour
{
    public enum Type { SHOTGUN, SOAKER, HEALTH, ARMOR};

    public virtual void Pickup() { }
}

 

