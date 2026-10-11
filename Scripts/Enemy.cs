using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform player;
    public float speed = 3f;
    public float chaseRange = 10f;
    public int health = 30;
    public GameObject fireEffectPrefab;   // 火焰特效预制体

    // 标记是否正在燃烧，防止重复叠加
    private bool isBurning = false;
    private GameObject currentFireEffect;

    void Start()
    {
        // 自动找 tag 为 Player 的物体
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void Update()
    {
        if (player == null) return;

        float dist = Vector3.Distance(transform.position, player.position);
        if (dist < chaseRange)
        {
            transform.LookAt(player);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        print("敌人剩余生命为" + health);
        if (health <= 0)
        {
            Destroy(gameObject);
            GameObject.FindObjectOfType<ScoreManager>()?.AddScore(10);
        }
    }
    
    public void StartBurn()
    {
        if (isBurning) return; // 已在燃烧则忽略重复触发
        isBurning = true;

        if (fireEffectPrefab != null)
        {
            currentFireEffect = Instantiate(fireEffectPrefab, transform.position, Quaternion.identity);
            currentFireEffect.transform.SetParent(transform, true);
        }

        // 启动协程：每隔 1 秒扣 10 点，执行 2 次（共 20 点）
        StartCoroutine(BurnCoroutine());
    }

    private IEnumerator BurnCoroutine()
    {
        for (int i = 0; i < 2; i++)
        {
            yield return new WaitForSeconds(1f);
            TakeDamage(10);
        }

        // 燃烧结束，清理
        isBurning = false;
        if (currentFireEffect != null)
        {
            Destroy(currentFireEffect, 0.5f);
            currentFireEffect = null;
        }
    }
}