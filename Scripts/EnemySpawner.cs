using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public int waveCount = 5;
    public float spawnRange = 20f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnWave), 1f, 30f);
    }

    void SpawnWave()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        Vector3 center = playerObj.transform.position;

        for (int i = 0; i < waveCount; i++)
        {
            float x = center.x + Random.Range(-spawnRange, spawnRange);
            float z = center.z + Random.Range(-spawnRange, spawnRange);
            Vector3 pos = new Vector3(x, 1f, z);

            Instantiate(enemy, pos, Quaternion.identity);
        }
    }
}