using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    // 对外暴露当前/最大生命值与变化事件
    public int CurrentHealth => currentHealth;
    public int MaxHealth => maxHealth;
    public Action<int, int> OnHealthChanged; // (current, max)

    void Start()
    {
        currentHealth = maxHealth;
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log(gameObject.name + " 剩余血量：" + currentHealth);

        OnHealthChanged?.Invoke(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10);
        }
    }

    void Die()
    {
        Debug.Log("游戏结束");
        Time.timeScale = 0f;
    }
}