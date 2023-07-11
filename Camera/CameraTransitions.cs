using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraTransitions : MonoBehaviour
{
    public GameObject player;
    private PlayerController playerController;

    public GameObject cinemachine;
    public Vector3 cinemachineTargetPos;
    public Vector2 playerTargetPos;

    public float cameraMoveSpeed = 5f;
    public float playerMoveSpeedTransition;

    private CameraTransitionColliders cameraColliders;

    public bool enteredTransition;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        cameraColliders = FindObjectOfType<CameraTransitionColliders>();
        enteredTransition = false;
    }


    
    void FixedUpdate()
    {

        if (enteredTransition)
        {
            if (cinemachine.transform.position != cinemachineTargetPos)
            {
                Debug.Log("entering camera transistion");
                MoveCamera();


            }

        }

        
    }



    public void MoveCamera()
    {
        playerController.canControlMovement = false;
        Vector3 movementDirection = (cinemachineTargetPos - cinemachine.transform.position).normalized;
        Vector3 movement = movementDirection * cameraMoveSpeed * Time.fixedDeltaTime;
        cinemachine.transform.position += movement;

        if(Vector3.Distance(cinemachine.transform.position, cinemachineTargetPos) <= 0.1f)
        {
            cinemachine.transform.position = cinemachineTargetPos;
            enteredTransition = false;
            cameraColliders.enteredTransition = false;
            cameraColliders.playerMovingToPosition = false;
            playerController.canControlMovement = true;
        }
        MovePlayer();
    }

    public void MovePlayer()
    {
        
        Rigidbody2D playerRB = player.GetComponent<Rigidbody2D>();
        Animator playerAnimator = player.GetComponent<Animator>();
        playerAnimator.SetBool("isMoving", true);

        Vector2 moveDirection = (playerTargetPos - playerRB.position).normalized;
        Vector2 movement = moveDirection * playerMoveSpeedTransition * Time.fixedDeltaTime;
        playerRB.position += movement;

        if (Vector2.Distance(playerRB.position, playerTargetPos) <= 0.1f)
        {
            
            playerRB.position = playerTargetPos;
            playerAnimator.SetBool("isMoving", false);
       
        }
    }
}
