using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public void TakeDamage(ref int health, int damage)
    {
        if (damage < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(damage));
        }

        if (damage <= health)
        {
            health -= damage;
        }

        if (health < 0)
        {
            health = 0;
        }
    }
}
