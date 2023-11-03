using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float JumpSpeed = 500f;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _sprite;
    public AudioSource _jumpsound;

    private bool _isGrounded = false;
    private bool _canJump = true;

    private float _XInput;
    private bool _isJumpPressed = false;

    

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        _jumpsound = GetComponent<AudioSource>();

    }

    void Update()
    {
        _XInput = Input.GetAxisRaw("Horizontal");

        if(_XInput == 0)
        {
            _animator.SetBool("IsWalking", false);
        }

        else
        {
            _animator.SetBool("IsWalking", true);
            if (_XInput > 0)
            {
                _sprite.flipX = true;
            }

            else
            {
                _sprite.flipX = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded && _canJump)
        {
            _isJumpPressed = true;
            _canJump = false;
            _jumpsound.Play();
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
            _canJump = true;
        }
    }
}
