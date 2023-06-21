using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerMovementController : MonoBehaviour
{

    [SerializeField]
    private float _moveVelocity = 250;
    private float _leftRight;
    private Rigidbody2D _rigidBody;
    private Animator _animator;
    private SpriteRenderer _renderer;
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        _leftRight = Input.GetAxis("Horizontal");
        HandleAnimator();
        HandleSpriteFlip();
    }

    void HandleSpriteFlip()
    {
        if (_leftRight < 0)
        {
            _renderer.flipX = true;
        }
        else if (_leftRight > 0)
        {
            _renderer.flipX = false;
        }
    }

    void HandleAnimator()
    {
        _animator.SetBool("isRunning", _leftRight != 0);
    }

    void FixedUpdate()
    {
        float xVelocity = _leftRight * _moveVelocity * Time.fixedDeltaTime;
        Vector2 newVelocity = new (xVelocity, _rigidBody.velocity.y);
        _rigidBody.velocity = newVelocity;
    }
}
