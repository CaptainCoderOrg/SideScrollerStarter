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
    [SerializeField]
    private Transform _groundCheck;
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
        // float distance = _collider.bounds.extents.y + _distanceDelta;
        // RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, Vector2.down, distance, _platformLayer);
        Debug.DrawRay(transform.position, Vector2.down, Color.yellow, 1);
        // _isOnGround = raycastHit.collider != null;

        RaycastHit2D raycastHit = Physics2D.BoxCast(_groundCheck.position, new Vector2(_collider.bounds.size.x, _distanceDelta), 0, Vector2.down, _distanceDelta, _platformLayer);
        _isOnGround = raycastHit.collider != null;
        // Physics2D.OverlapBox
        // _isOnGround = collision != null;

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

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        _collider ??= GetComponent<Collider2D>();
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(_groundCheck.position, new Vector2(_collider.bounds.size.x, _distanceDelta));
    }

    private void PerformJump()
    {
        if (_isOnGround)
        {
            _rigidBody.AddForce(Vector2.up * _jumpStrength, ForceMode2D.Impulse);
        }
    }
}
