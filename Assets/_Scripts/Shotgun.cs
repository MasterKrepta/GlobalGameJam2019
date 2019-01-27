using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour, IWeapon
{
    [SerializeField] Transform bullet;
    [SerializeField] GameObject barrelParent;
    List<Transform> barrels = new List<Transform>();
    public float fireDelay;
    public bool canFire = true;
    Animator anim;

    private void Start() {
  
        GetBarrels();
        anim = GetComponent<Animator>();
        anim.StopPlayback();
    }

    public void Fire() {
        if (Inventory.instance.shotgunAmmo > 0) {

            Inventory.instance.shotgunAmmo--;
            anim.Play("Fire");
            SoundManager.instance.PlayClip(SoundManager.instance.shotgun);
            if (canFire) {
                canFire = false;
                foreach (Transform barrel in barrels) {
                    Instantiate(bullet, barrel.position, barrel.rotation);
                }

                StartCoroutine(resetFireDelay());
            }
        }
        else {
            Debug.Log("shotgun ammo empty");
            Inventory.instance.shotgunAmmo = 0;
        }
    }

    private IEnumerator resetFireDelay() {
        yield return new WaitForSeconds(fireDelay);
        canFire = true;
    }

    public void GetBarrels() {
        barrels.Clear();
        int children = barrelParent.transform.childCount;

        for (int i = 0; i < children; ++i)
            barrels.Add(barrelParent.transform.GetChild(i));
    }

    public void InitAfterSwitch() {

     
        canFire = true;
        GetBarrels();
       //Debug.Log(this.name + " is ready to fire");
    }
}
