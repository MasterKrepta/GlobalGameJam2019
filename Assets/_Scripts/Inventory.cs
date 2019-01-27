using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;


    public int shotgunAmmo =20;
    public int soakerAmmo = 20;

    // Start is called before the first frame update
   
        void Awake() {
            if (instance == null)
                instance = this;
          
            else if (instance != this)
                Destroy(gameObject);

            //DontDestroyOnLoad(gameObject);
        }
    void Start()
    {
   
    }

    private void OnTriggerEnter(Collider other) {
        //Debug.Log(other.name);
        Ammo a = other.GetComponent<Ammo>();
        if (a != null) {
            a.Pickup();
            SoundManager.instance.PlayClip(SoundManager.instance.pickup);
            Destroy(other.gameObject);
            UpdateUi.UpdateStats();
        }
    }
}
