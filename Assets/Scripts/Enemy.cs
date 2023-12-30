using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : Creature, ICollidable
{
    private void Awake()
    {
        MaxHealth = 5;
        Damage = 1;
        CurrentHealth = MaxHealth;
    }

    public void HandleCollisionWithPlayer(Player player)
    {
        player.TakeDamage(Damage);
        TakeDamage(player.Damage);
    }
}
