using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMovement), typeof(PlayerAnimation))]
public class Player : Creature
{
    [SerializeField] private Enemy _enemy;

    private PlayerMovement _playerMovement;
    private PlayerAnimation _playerAnimation;
    private bool _isAbilityActive;

    private Coroutine _healthDrainJob;

    private void Awake()
    {
        MaxHealth = 10;
        Damage = 2;
        CurrentHealth = MaxHealth;

        _playerMovement = GetComponent<PlayerMovement>();
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void Update()
    {
        TryTakeHealth(_enemy);

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

        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }

        InvokeEventHealthChanged(CurrentHealth);
    }

    private void TryTakeHealth(Enemy enemy)
    {
        float range = 3;

        if (Vector2.Distance(transform.position, enemy.transform.position) < range && _isAbilityActive == false)
        {
            if(Input.GetMouseButtonDown(0))
            {
                if (_healthDrainJob != null)
                {
                    StopCoroutine(_healthDrainJob);
                }

                _healthDrainJob = StartCoroutine(HealthDrainCoroutine(enemy));
            }
        }
    }

    private IEnumerator HealthDrainCoroutine(Enemy enemy)
    {
        var waitForOneSecond = new WaitForSeconds(1);

        int healthToTake = 1;
        int durationOfEffect = 6;

        for (int i = 0; i < durationOfEffect; i++)
        {
            _isAbilityActive = true;

            enemy.TakeDamage(healthToTake);
            Heal(healthToTake);

            yield return waitForOneSecond;
        }

        _isAbilityActive = false;
    }
}