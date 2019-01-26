using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    Animator anim;
    [SerializeField] GameObject[] guns;
     int gunId;
     GameObject oldGun;
     GameObject newGun;
    [SerializeField] GameObject currentGun;


    IWeapon active;

    // Start is called before the first frame update
    void Start()
    {
        
        currentGun = guns[gunId];
        newGun = guns[1];
        active = currentGun.GetComponent<IWeapon>();
        anim = currentGun.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        active = currentGun.GetComponent<IWeapon>();
        if (Input.GetMouseButtonDown(0)) {
            active.Fire();
        }
        var d = Input.GetAxis("Mouse ScrollWheel");
        if (d!= 0) {
            SwitchGuns();
        }
    }

    void SwitchGuns() {

        if (gunId == 0) {
            oldGun = currentGun;
            newGun = guns[1];
            gunId = 1;
        }
        else {
            oldGun = currentGun;
            newGun = guns[0];
            gunId = 0;
        }
        ShowHideGuns(oldGun, newGun);
    }

    void ShowHideGuns(GameObject oldGun, GameObject newgun) {
        oldGun.SetActive(false);
        newgun.SetActive(true);
        currentGun = newGun;
        currentGun.GetComponent<IWeapon>().InitAfterSwitch();
    }
}
