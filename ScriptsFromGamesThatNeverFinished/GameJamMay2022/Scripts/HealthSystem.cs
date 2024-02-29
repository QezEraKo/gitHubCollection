using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    // public event EventHandler OnDamaged;
    // public event EventHandler OnDied;
    // public event Event

    private int healthAmountMax = 100;
    [SerializeField] private int healthAmount;

    public event EventHandler OnDamaged;
    public event EventHandler OnDied;

    private void Awake()
    {
        healthAmount = healthAmountMax;
    }

    public void Damage(int damage)
    {
        healthAmount -= damage;
        healthAmount = Mathf.Clamp(healthAmount, 0, healthAmountMax);

        OnDamaged?.Invoke(this, EventArgs.Empty);

        if (IsDead())
        {
            OnDied?.Invoke(this, EventArgs.Empty);
        }
    }

    public bool IsFullHealth()
    {
        return healthAmount == healthAmountMax;
    }

    public bool IsDead()
    {
        return healthAmount == 0;
    }

    public int GetHealthAmount()
    {
        return healthAmount;
    }

    public float GetHealthAmountNormalised()
    {
        return (float)healthAmount / healthAmountMax;
    }

    public void SetHealthAmountMax(int healthAmountMax, bool updateHealthAmount)
    {
        this.healthAmountMax = healthAmountMax;

        if (updateHealthAmount)
        {
            healthAmount = healthAmountMax;
        }
    }

}
