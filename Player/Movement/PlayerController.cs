using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;
    // Using public float so user can change in the inspector to test different moveSpeeds etc.

    private Rigidbody2D _rb;
    public Vector2 moveDirection;
    private Animator animator;
    private bool isMoving;

    public bool canControlMovement;
    


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isMoving = false;
        canControlMovement = true;
    }

    
    private void FixedUpdate()
    {
        
        Vector2 movement = (moveDirection * moveSpeed * Time.fixedDeltaTime);
        // creating vector2 to store variable for movement
        _rb.position += movement;
        // using the rigidbody2d position and adding the movement variable to change the rigidbody2d position.
        if (!canControlMovement)
        {
            moveDirection = Vector2.zero;
        }
    }

    private void OnMove(InputValue value)
    {

        if (canControlMovement)
        {
            moveDirection = value.Get<Vector2>().normalized;

            if (moveDirection != Vector2.zero)
            {
                isMoving = true;
                animator.SetFloat("x", moveDirection.x);
                animator.SetFloat("y", moveDirection.y);
                animator.SetBool("isMoving", isMoving);
            }
            else
            {
                isMoving = false;
                animator.SetBool("isMoving", isMoving);
            }
        }
        
    }

    
}
