using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransitionColliders : MonoBehaviour
{
    private CameraTransitions cameraTransitions;
    public Vector3 cinemachineTargetPos;
    public Vector2 playerTargetPos;
    public float assignMoveSpeedPlayer;
    public float assignCameraMovementSpeed;

    public bool enteredTransition;
    public bool playerMovingToPosition;

    private void Start()
    {
        cameraTransitions = FindObjectOfType<CameraTransitions>();
        //enteredTransition = false;
        //playerMovingToPosition = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (cameraTransitions.enteredTransition == true)
        {
            return;
        }
        else if (cameraTransitions.enteredTransition == false)
        {
            Debug.Log("hit edge collider");
            enteredTransition = true;
            cameraTransitions.enteredTransition = true;
            cameraTransitions.playerMoveSpeedTransition = assignMoveSpeedPlayer;
            cameraTransitions.cameraMoveSpeed = assignCameraMovementSpeed;
            Debug.Log("entered Transition bool is " + enteredTransition);

            if (collision.CompareTag("Player"))
            {
                playerMovingToPosition = true;
                Debug.Log("player moving to position bool is " + playerMovingToPosition);
                cameraTransitions.cinemachineTargetPos = cinemachineTargetPos;
                cameraTransitions.playerTargetPos = playerTargetPos;

            }
        }
        
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        Invoke("ChangeBools", 3f);
    }

    public void ChangeBools()
    {
        enteredTransition = false;
        playerMovingToPosition = false;
    }
}
