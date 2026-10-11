using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public GameObject fireBulletPrefab;   // 火焰子弹预制体，Inspector 拖
    private int fireBulletCount = 0;

    public void SwitchToFireBullet(int count)
    {
        fireBulletCount = count;
    }

    void Shoot()
    {
        GameObject prefab = bullet;

        if (fireBulletCount > 0)
        {
            prefab = fireBulletPrefab;
            fireBulletCount--;
        }

        Debug.Log("打出去：" + prefab.name + " | 火焰子弹剩余：" + fireBulletCount);
        Instantiate(prefab, firePoint.position, firePoint.rotation);
    }
}