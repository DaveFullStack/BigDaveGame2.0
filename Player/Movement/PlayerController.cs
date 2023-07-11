using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;
    // Using public float so user can change in the inspector to test different moveSpeeds etc.

    private Rigidbody2D _rb;
    private Vector2 moveDirection;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    
    private void FixedUpdate()
    {
        
        Vector2 movement = (moveDirection * moveSpeed * Time.fixedDeltaTime);
        _rb.position += movement;
    }

    private void OnMove(InputValue value)
    {
        moveDirection = value.Get<Vector2>().normalized;
    }
}
