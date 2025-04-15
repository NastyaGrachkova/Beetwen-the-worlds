using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]

public class Player_movement : MonoBehaviour
{
    [SerializeField] private float _playerSpeed;
    [SerializeField] private float _jumpForce;
    private Rigidbody2D _rigidbody2D;
    private bool _isOnGround = true;
    private bool _isUseDoubleJump = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        if (_rigidbody2D.linearVelocity.y == 0)
        {
            _isOnGround = true;
            _isUseDoubleJump = false;
        }
        _rigidbody2D.linearVelocity = new Vector2(moveInput*_playerSpeed, _rigidbody2D.linearVelocity.y);
        if (Input.GetButtonDown("Jump") && _isOnGround)
        {
            _isOnGround = false;
            _rigidbody2D.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        }
        else if (Input.GetButtonDown("Jump") && _isUseDoubleJump == false)
        {
            _rigidbody2D.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
            _isUseDoubleJump = true;
        }
    }
}
