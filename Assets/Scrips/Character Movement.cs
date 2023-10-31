using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float JumpSpeed = 500f;

    private Rigidbody2D _rigidbody;

    private bool _isGrounded = false;

    private float _XInput;
    private bool _isJumpPressed = false;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _XInput = Input.GetAxisRaw("Horizontal");
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isJumpPressed = true;
        }
    }

    private void FixedUpdate()
    {
        //_rigidbody.AddForce(new Vector2(_XInput,0f), ForceMode2D.Impulse);

        _rigidbody.velocity = new Vector2(_XInput * MoveSpeed * Time.deltaTime, _rigidbody.velocity.y);
        //_XInput *= MoveSpeed * Time.deltaTime;

        if (_isJumpPressed && _isGrounded)
        {
            _rigidbody.AddForce(Vector2.up * JumpSpeed, ForceMode2D.Impulse);
        }
        _isJumpPressed = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
       if (collision.transform.tag == "Ground")
        {
            _isGrounded = true;
        }
    }
}
