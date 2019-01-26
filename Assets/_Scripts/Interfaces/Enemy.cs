using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Enemy", order = 1)]
public class Enemy : ScriptableObject
{
    public float maxHealth;
    public float damageDealt;
    public float moveSpeed;
    
}
