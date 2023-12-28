using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(PlayerAnimation))]
public class Player : MonoBehaviour 
{
    private int _health;
    private int _maxHealth = 10;

    private PlayerMovement _playerMovement;
    private PlayerAnimation _playerAnimation;

    private void Start()
    {
        _health = _maxHealth;

        _playerMovement = GetComponent<PlayerMovement>();
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void Update()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");

        _playerAnimation.SetSpeed(inputHorizontal);
        _playerAnimation.SetIsJumping(_playerMovement.IsGrounded == false);
        _playerAnimation.SetIsFalling(_playerMovement.IsGrounded == false && _playerMovement.GetRigidbody2D().velocity.y < 0);
    }

    public void Heal(int value)
    {
        _health += value;

        if(_health > _maxHealth)
        {
            _health = _maxHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        if(damage < 0) 
        {
            throw new ArgumentOutOfRangeException(nameof(damage));
        }

        if(damage <= _health)
        {
            _health -= damage;
        }
        
        if(_health < 0)
        {
            _health = 0;
        }
    }
}
