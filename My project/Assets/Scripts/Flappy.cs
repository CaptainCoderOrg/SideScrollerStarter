using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flappy : MonoBehaviour
{
    public float _jumpForce;
    public float _torqueDown = -1;
    public float _torqueUp = 5;
    public Rigidbody2D _rigidBody;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            RotateUp();
        }
        else
        {
            RotateDown();
        }
    }

    void RotateUp()
    {
        _rigidBody.SetRotation(0);
    }

    void RotateDown()
    {
        // GetComponent<Rigidbody2D>().AddTorque(_torqueDown);
        float nextRotation = _rigidBody.rotation - 600*Time.deltaTime;
        nextRotation = Mathf.Clamp(nextRotation, -180, 0);
        _rigidBody.MoveRotation(nextRotation);
        
    }
}
