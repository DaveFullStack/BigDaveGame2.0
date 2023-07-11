using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraTransitions : MonoBehaviour
{
    public GameObject player;
    //private PlayerController playerContorller;

    public GameObject cinemachine;
    public Vector3 cinemachineTargetPos;
    public Vector2 playerTargetPos;

    public float cameraMoveSpeed = 5f;
    public float playerMoveSpeedTransition;

    private CameraTransitionColliders cameraColliders;

    private void Start()
    {
        //playerContorller = FindObjectOfType<PlayerController>();
        cameraColliders = FindObjectOfType<CameraTransitionColliders>();
    }


    // Update is called once per frame
    void Update()
    {
        
        if (cameraColliders.enteredTransition == true)
        {
            Debug.Log("entering camera transistion");
            MoveCamera();
            if (Vector3.Distance(cinemachine.transform.position, cinemachineTargetPos) <= 0.5f)
            {
                cinemachine.transform.position = cinemachineTargetPos;
                cameraColliders.enteredTransition = false;
            }
        }
        if (cameraColliders.playerMovingToPosition)
        {
            if (player.GetComponent<Rigidbody2D>().position != playerTargetPos)
            {
                MovePlayer();
                Debug.Log("MovingPlayer");
            }
        }

    }



    public void MoveCamera()
    {
        Vector3 movementDirection = (cinemachineTargetPos - cinemachine.transform.position).normalized;
        Vector3 movement = movementDirection * cameraMoveSpeed * Time.fixedDeltaTime;
        cinemachine.transform.position += movement;

        
    }

    public void MovePlayer()
    {
        Rigidbody2D playerRB = player.GetComponent<Rigidbody2D>();

        Vector2 moveDirection = (playerTargetPos - playerRB.position).normalized;
        Vector2 movement = moveDirection * playerMoveSpeedTransition * Time.fixedDeltaTime;
        playerRB.position += movement;
        if (Vector2.Distance(playerRB.position, playerTargetPos) <= 0.1f)
        {
            playerRB.position = playerTargetPos;
            cameraColliders.playerMovingToPosition = false;
        }
    }
}
