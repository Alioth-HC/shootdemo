using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulletPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))   // Ö»ÓÐ Player ²Å¼ñ
        {
            PlayerShoot shoot = other.GetComponent<PlayerShoot>();
            if (shoot != null)
            {
                shoot.SwitchToFireBullet(3);
            }
            Destroy(gameObject);
        }
    }
}