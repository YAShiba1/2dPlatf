using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : Creature, ICollidable
{
    public Enemy()
    {
        MaxHealth = 5;
        Damage = 1;
    }

    public void HandleCollisionWithPlayer(Player player)
    {
        player.TakeDamage(Damage);
        TakeDamage(player.Damage);
    }
}
