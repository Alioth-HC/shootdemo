using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : Bullet
{
    protected override void OnHit(Collider other)
    {
        base.OnHit(other);

        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.StartBurn();
            }
        }
    }
}