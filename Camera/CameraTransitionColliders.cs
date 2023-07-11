using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransitionColliders : MonoBehaviour
{
    private CameraTransitions cameraTransitions;
    public Vector3 cinemachineTargetPos;
    public Vector2 playerTargetPos;

    public bool enteredTransition;
    public bool playerMovingToPosition;

    private void Start()
    {
        cameraTransitions = FindObjectOfType<CameraTransitions>();
        enteredTransition = false;
        playerMovingToPosition = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit line collider");
        enteredTransition = true;

            if (collision.CompareTag("Player"))
            {
                playerMovingToPosition = true;
                cameraTransitions.cinemachineTargetPos = cinemachineTargetPos;
                cameraTransitions.playerTargetPos = playerTargetPos;
            }
            
        
        
    }
}
