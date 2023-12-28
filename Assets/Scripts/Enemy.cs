using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ICollidable
{
    private int _damage = 1;

    public void HandleCollisionWithPlayer(Player player)
    {
        player.TakeDamage(_damage);
    }
}
