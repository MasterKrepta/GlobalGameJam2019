using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateUi : MonoBehaviour
{
    public static UpdateUi instance = null;
    [SerializeField] TMP_Text ammoCount;
    [SerializeField] TMP_Text health;
    [SerializeField] TMP_Text armor;
    [SerializeField] TMP_Text acid;
    [SerializeField] TMP_Text shells;

    PlayerHealth player;
    Shooting shooting;

    void Awake() {
        player = FindObjectOfType<PlayerHealth>();
        shooting = player.GetComponent<Shooting>();
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);



        //DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateStats();
    }



    public static void UpdateStats() {
        instance.shells.text = "acid: " + Inventory.instance.shotgunAmmo.ToString();
        instance.acid.text = "shells: " + Inventory.instance.soakerAmmo.ToString();
        instance.health.text = instance.player.currentHealth.ToString();
        instance.armor.text = instance.player.currentArmor.ToString();
        if (instance.shooting.currentGun.name == "superSoaker Variant") {
            instance.ammoCount.text = Inventory.instance.soakerAmmo.ToString();
        }
        else {
            instance.ammoCount.text = Inventory.instance.shotgunAmmo.ToString();
        }
       
    }
}
