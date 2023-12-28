using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : MonoBehaviour, ICollidable
{
    private int _healPoints = 1;

    public void HandleCollisionWithPlayer(Player player)
    {
        player.Heal(_healPoints);
        gameObject.SetActive(false);
    }
}
