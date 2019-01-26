using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //[SerializeField] Transform barrel;
    [SerializeField] Transform bullet;
    [SerializeField] GameObject[] guns;
     int gunId;
     GameObject oldGun;
     GameObject newGun;
    [SerializeField] GameObject currentGun;
    List<Transform> barrels = new List<Transform>();
    [SerializeField] float fireDelay;
    bool canFire = true;

    IWeapon active;

    // Start is called before the first frame update
    void Start()
    {
        currentGun = guns[gunId];
        newGun = guns[1];
        active = currentGun.GetComponent<IWeapon>();
        // GetBarrels();
    }

    // Update is called once per frame
    void Update()
    {
        active = currentGun.GetComponent<IWeapon>();
        if (Input.GetMouseButtonDown(0)) {
            active.Fire();
           //Fire();
        }
        var d = Input.GetAxis("Mouse ScrollWheel");
        if (d!= 0) {
            SwitchGuns();
            
        }
 
    }

    //private void Fire() {
    //    canFire = false;
    //     foreach (Transform barrel in barrels) {
    //        Instantiate(bullet, barrel.position, barrel.rotation);
    //    }

    //    StartCoroutine(resetFireDelay());
    //}

    //private IEnumerator resetFireDelay() {
    //    yield return new WaitForSeconds(fireDelay);
    //    canFire = true;
    //}

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
        currentGun.GetComponent<IWeapon>().InitAfterSwitch(); ;
        
        //GetBarrels();
    }

    //private void GetBarrels() {
    //    barrels.Clear();
    //    int children = currentGun.transform.childCount;

    //    for (int i = 0; i < children; ++i)
    //        barrels.Add(currentGun.transform.GetChild(i));
    //}
}
