using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAmmo : MonoBehaviour
{
    [SerializeField] List<Transform> ammoToSpawn = new List<Transform>();
    [SerializeField] List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] float spawnRate = 10f;
  

    // Start is called before the first frame update
    void Start() {
        Spawn();
        StartCoroutine(WaitForNextWave());
    }

    void Spawn() {
        int randPoint = GetRandomIndex(spawnPoints.Count);
        int randEnemy = GetRandomIndex(ammoToSpawn.Count);
        Instantiate(ammoToSpawn[randEnemy], spawnPoints[randPoint].position, ammoToSpawn[randEnemy].rotation);
        StartCoroutine(WaitForNextWave());
    }

    IEnumerator WaitForNextWave() {
        yield return new WaitForSeconds(spawnRate);

        Spawn();
    }
    int GetRandomIndex(int maxCount) {
        return Random.Range(0, maxCount);
    }
}
