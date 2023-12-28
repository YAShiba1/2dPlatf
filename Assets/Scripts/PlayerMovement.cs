using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody2D;
    private bool _isFacingRight = true;
    private bool _isGrounded;

    public bool IsGrounded => _isGrounded;

    public Rigidbody2D GetRigidbody2D()
    {
        return _rigidbody2D;
    }

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

    private void Move()
    {
        float inputHorizontal;

        inputHorizontal = Input.GetAxis("Horizontal");
        _rigidbody2D.velocity = new Vector2(inputHorizontal * _speed, _rigidbody2D.velocity.y);

        if (_isFacingRight == false && inputHorizontal > 0)
        {
            Flip();
        }
        else if (_isFacingRight == true && inputHorizontal < 0)
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

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
