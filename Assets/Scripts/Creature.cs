using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class Creature : MonoBehaviour
{
    public int MaxHealth { get; protected set; }
    public int MinHealth { get; protected set; } = 0;
    public int CurrentHealth { get; protected set; }
    public int Damage { get; protected set; }

    public event UnityAction<float> HealthChanged;

    public void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(damage));
        }

        CurrentHealth -= damage;

        if (CurrentHealth < 0)
        {
            CurrentHealth = 0;
        }

        HealthChanged?.Invoke(CurrentHealth);
    }

    protected void InvokeEventHealthChanged(int value)
    {
        HealthChanged?.Invoke(value);
    }
}
