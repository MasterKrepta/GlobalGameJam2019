using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] List<Transform> enemiesToSpawn = new List<Transform>();
    [SerializeField] List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] float spawnRate = 10f;
    [SerializeField] float numToSpawn = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        InitSpawn();
   
        StartCoroutine(WaitForNextWave());
    }

    void InitSpawn() {
        for (int i = 0; i < spawnPoints.Count; i++) {
            int randEnemy = GetRandomIndex(enemiesToSpawn.Count);
            Instantiate(enemiesToSpawn[randEnemy], spawnPoints[i].position, Quaternion.identity);
        }
        StartCoroutine(WaitForNextWave());
    }
    void SpawnWave() {
        for (int i = 0; i < numToSpawn; i++) {
            int randPoint = GetRandomIndex(spawnPoints.Count);
            int randEnemy = GetRandomIndex(enemiesToSpawn.Count);
            Instantiate(enemiesToSpawn[randEnemy], spawnPoints[randPoint].position, Quaternion.identity);
  
        }
        StartCoroutine(WaitForNextWave());
    }

    IEnumerator WaitForNextWave() {
        yield return new WaitForSeconds(spawnRate);
        //numToSpawn++;
        SpawnWave();
    }
    int GetRandomIndex(int maxCount) {
        return Random.Range(0, maxCount);
    }
   
}
