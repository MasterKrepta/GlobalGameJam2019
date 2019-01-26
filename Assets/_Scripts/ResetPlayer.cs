using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{

    PlayerHealth player;
    [SerializeField] List<Transform> checkPoints = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType < PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other == player.GetComponent<Collider>()) {
   
            player.transform.position = GetClosestCheckpoint().position;
        }
        else {
            Destroy(other.gameObject);
        }
    }

    Transform GetClosestCheckpoint() {
        Transform shortest = checkPoints[0];
        foreach (Transform t in checkPoints) {
            if (Vector3.Distance(player.transform.position, t.position) < 
                Vector3.Distance(player.transform.position, shortest.position)) {
                shortest = t;
            }

            }
        return shortest;
        
    }
}
