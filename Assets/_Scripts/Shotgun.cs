using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour, IWeapon
{
    [SerializeField] Transform bullet;
    List<Transform> barrels = new List<Transform>();
    public float fireDelay;
    public bool canFire = true;

    private void Start() {
        GetBarrels();
    }

    public void Fire() {
        if (canFire) {
            canFire = false;
            foreach (Transform barrel in barrels) {
                Instantiate(bullet, barrel.position, barrel.rotation);
            }

            StartCoroutine(resetFireDelay());
        }

        
    }

    private IEnumerator resetFireDelay() {
        yield return new WaitForSeconds(fireDelay);
        canFire = true;
    }

    public void GetBarrels() {
        barrels.Clear();
        int children = this.transform.childCount;

        for (int i = 0; i < children; ++i)
            barrels.Add(this.transform.GetChild(i));
    }

    public void InitAfterSwitch() {

        //StopAllCoroutines();
        canFire = true;
        GetBarrels();
        Debug.Log(this.name + " is ready to fire");
    }
}
