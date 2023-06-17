using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

    [SerializeField]
    private float _moveVelocity = 250;
    private float _leftRight;
    private Rigidbody2D _rigidBody;
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        _leftRight = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        float xVelocity = _leftRight * _moveVelocity * Time.fixedDeltaTime;
        Vector2 newVelocity = new (xVelocity, _rigidBody.velocity.y);
        _rigidBody.velocity = newVelocity;
    }
}
