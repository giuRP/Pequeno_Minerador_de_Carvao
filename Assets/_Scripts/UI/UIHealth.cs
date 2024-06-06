using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    [SerializeField]
    private Slider healthBar;

    [SerializeField]
    private TextMeshProUGUI textMesh;

    private void Awake()
    {
        healthBar = GetComponentInChildren<Slider>();
        textMesh = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Initialize(float maxHealth)
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = healthBar.maxValue;

        textMesh.text = $"{maxHealth}/100";
    }

    public void SetHealth(float currentHealth)
    {
        healthBar.value = currentHealth;

        textMesh.text = $"{currentHealth}/100";
    }
}
