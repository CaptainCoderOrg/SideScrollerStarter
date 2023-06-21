using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpController : MonoBehaviour
{
    [SerializeField]
    private bool _isOnGround;
    [SerializeField]
    private float _jumpStrength = 5;
    [SerializeField]
    private float _distanceDelta = 0.1f;
    [SerializeField]
    private LayerMask _platformLayer;
    private Rigidbody2D _rigidBody;
    private Collider2D _collider;
    private void Awake()
    {
        // cache the values
        _rigidBody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        // _platformLayer = LayerMask.NameToLayer("Platform");
    }
    // Update is called once per frame
    void Update()
    {
        CheckGround();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PerformJump();
        }
    }

    private void CheckGround()
    {
        float distance = _collider.bounds.extents.y + _distanceDelta;
        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, Vector2.down, distance, _platformLayer);
        _isOnGround = raycastHit.collider != null;
        // The code below is equivalent in logic
        // if (raycastHit.collider != null)
        // {
        //     _isOnGround = true;
        // }
        // else
        // {
        //     _isOnGround = false;
        // }
    }

    private void PerformJump()
    {
        if (_isOnGround)
        {
            _rigidBody.AddForce(Vector2.up * _jumpStrength, ForceMode2D.Impulse);
        }
    }
}
