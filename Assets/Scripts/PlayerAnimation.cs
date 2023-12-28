using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;

    private int _speedHash = Animator.StringToHash("Speed");
    private int _isJumpingHash = Animator.StringToHash("IsJumping");
    private int _isFallingHash = Animator.StringToHash("IsFalling");

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetSpeed(float speed)
    {
        _animator.SetFloat(_speedHash, Mathf.Abs(speed));
    }

    public void SetIsJumping(bool isJumping)
    {
        _animator.SetBool(_isJumpingHash, isJumping);
    }

    public void SetIsFalling(bool isFalling)
    {
        _animator.SetBool(_isFallingHash, isFalling);
    }
}
