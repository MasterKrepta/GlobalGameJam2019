using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOverTime: MonoBehaviour
{

    [SerializeField]float rotSpeed = 200f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(transform.up, rotSpeed * Time.deltaTime);
        
    }
}
