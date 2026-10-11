using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Health playerHealth;        // 在 Inspector 指定或自动查找 Tag 为 Player 的对象上的组件
    public Slider healthSlider;        // 指向场景中的 Slider
    public Image fillImage;            // 指向 Slider 的 Fill Image（用于颜色渐变）
    public Color fullColor = Color.green;
    public Color zeroColor = Color.red;

    void Start()
    {
        if (playerHealth == null)
        {
            var playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null) playerHealth = playerObj.GetComponent<Health>();
        }

        if (playerHealth == null || healthSlider == null)
        {
            Debug.LogWarning("HealthBarUI: 请在 Inspector 指定 playerHealth 与 healthSlider。");
            enabled = false;
            return;
        }

        // 如果没有手动拖 fillImage，尝试自动从 Slider 的 fillRect 获取 Image
        if (fillImage == null && healthSlider.fillRect != null)
        {
            fillImage = healthSlider.fillRect.GetComponent<Image>();
            if (fillImage == null)
            {
                Debug.LogWarning("HealthBarUI: healthSlider.fillRect 上未找到 Image 组件，请检查 Slider 结构。");
            }
        }

        healthSlider.maxValue = playerHealth.MaxHealth;
        UpdateUI(playerHealth.CurrentHealth, playerHealth.MaxHealth);

        playerHealth.OnHealthChanged += UpdateUI;
    }

    void OnDestroy()
    {
        if (playerHealth != null)
            playerHealth.OnHealthChanged -= UpdateUI;
    }

    void UpdateUI(int current, int max)
    {
        healthSlider.maxValue = max;
        healthSlider.value = current;

        if (fillImage != null && max > 0)
        {
            float t = (float)current / max;
            fillImage.color = Color.Lerp(zeroColor, fullColor, t);
        }
    }
}