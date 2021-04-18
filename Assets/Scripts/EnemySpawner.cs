using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // INSPECTOR에서 설정 
    public GameObject enemy;
    public GameObject[] spawnPoint = new GameObject[8];
    public float lastSpawnTime = -10f;

    private void Update()
    {
        if (!CanSpawn())
            return;
        int randomIndex = Random.Range(0, spawnPoint.Length);
        GameObject spawn = Instantiate(enemy,spawnPoint[randomIndex].transform.position, spawnPoint[randomIndex].transform.rotation);
        lastSpawnTime = Time.time;
    }

    private bool CanSpawn()
    {
        return Time.time - lastSpawnTime >= GameManager.instance.frequencyEnemySpawn;
    }
}
