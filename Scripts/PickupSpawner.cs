using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject fireBulletPickup;   // 火焰子弹拾取物预制体

    void Start()
    {
        InvokeRepeating(nameof(SpawnPickup), 1f, 30f);
    }

    public void SpawnPickup()
    {
        Vector3 pos = new Vector3(Random.Range(-10f, 10f), 1f, Random.Range(-10f, 10f));
        Instantiate(fireBulletPickup, pos, Quaternion.identity);
    }
}
