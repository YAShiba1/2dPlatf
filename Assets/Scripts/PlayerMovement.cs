using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : Movement
{
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody2D;
    private bool _isGrounded;

    private const string Horizontal = "Horizontal";

    public bool IsGrounded => _isGrounded;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Ground>())
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Ground>())
        {
            _isGrounded = false;
        }
    }

    public Rigidbody2D GetRigidbody2D()
    {
        return _rigidbody2D;
    }

    public float GetInputHorizontal()
    {
        float inputHorizontal = Input.GetAxis(Horizontal);

        return inputHorizontal;
    }

    private void Move()
    {
        _rigidbody2D.velocity = new Vector2(GetInputHorizontal() * _speed, _rigidbody2D.velocity.y);

        if (_isFacingRight == false && GetInputHorizontal() > 0)
        {
            Flip();
        }
        else if (_isFacingRight == true && GetInputHorizontal() < 0)
        {
            Flip();
        }
    }

    private void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && IsGrounded)
        {
            _rigidbody2D.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}
