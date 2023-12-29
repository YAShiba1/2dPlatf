using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMovement), typeof(PlayerAnimation))]
public class Player : Creature 
{
    private PlayerMovement _playerMovement;
    private PlayerAnimation _playerAnimation;

    public Player()
    {
        MaxHealth = 10;
        Damage = 2;
    }

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void Update()
    {
        _playerAnimation.SetSpeed(_playerMovement.GetInputHorizontal());
        _playerAnimation.SetIsJumping(_playerMovement.IsGrounded == false);
        _playerAnimation.SetIsFalling(_playerMovement.IsGrounded == false && _playerMovement.GetRigidbody2D().velocity.y < 0);
    }

    public void Heal(int value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value));
        }

        CurrentHealth += value;

        if(CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }

        InvokeEventHealthChanged(CurrentHealth);
    }
}
