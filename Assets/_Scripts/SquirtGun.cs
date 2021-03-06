﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirtGun : MonoBehaviour, IWeapon
{
    [SerializeField] LineRenderer line;
    [SerializeField] Transform barrel;

    private void Start() {
       
        line.enabled = false;
    }
    public void Fire() {
        if (Input.GetMouseButton(0)) {

                StopCoroutine(FireWaterStream());
                StartCoroutine(FireWaterStream());
            
           

        }
    }
    IEnumerator FireWaterStream() {

            line.enabled = true;
            while (Input.GetMouseButton(0) && Inventory.instance.soakerAmmo >0) {
            SoundManager.instance.PlayClip(SoundManager.instance.water);
            Inventory.instance.soakerAmmo--;
                UpdateUi.UpdateStats();
            Ray ray = new Ray(barrel.position, transform.right);
                RaycastHit hit;
                line.SetPosition(0, ray.origin);
                if (Physics.Raycast(ray, out hit, 100)) {
                    line.SetPosition(1, hit.point);
                    IDamageable d = hit.transform.GetComponent<IDamageable>();
                    if (d != null) {
                        d.TakeDamage(1);
                    }
                }
                else {
                    line.SetPosition(1, ray.GetPoint(100));
                }

                yield return null;

            }
        SoundManager.instance.StopAudio();


        line.enabled = false;
    }

    public void GetBarrels() { }



    public void InitAfterSwitch() {}

  
}
