using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour, IHittable
{
    [SerializeField]
    private float maxHealth, currentHealth;

    public float CurrentHealth

    {
        get => currentHealth;

        set
        {
            currentHealth = value;
            OnHealthValueChange?.Invoke(currentHealth);
        }
    }

    public UnityEvent OnGetHit;
    public UnityEvent OnDie;
    public UnityEvent OnAddHealth;

    public UnityEvent<float> OnHealthValueChange;

    public UnityEvent<float> OnInitializeMaxHealth;

    public void GetHit(GameObject sender, float damage)
    {
        Hit(damage);
    }

    public void Hit(float damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth <= 0)
        {
            OnDie?.Invoke();
        }
        else
        {
            OnGetHit?.Invoke();
        }

        HealthManager.health = CurrentHealth;
    }

    public void Heal(int heal)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + heal, 0, maxHealth);
        OnAddHealth?.Invoke();
    }

    public void InitializeHealth(float health)
    {
        maxHealth = health;
        OnInitializeMaxHealth?.Invoke(maxHealth);
        CurrentHealth = maxHealth;
        if (HealthManager.health != 1337 && !(HealthManager.health <= 0))
        {
            CurrentHealth = HealthManager.health;
        }
    } 
}
