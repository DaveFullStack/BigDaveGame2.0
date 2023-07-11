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
        //enteredTransition = false;
        //playerMovingToPosition = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(enteredTransition)
        {
            return;
        }
        else
        {
            Debug.Log("hit line collider");
            enteredTransition = true;
            Debug.Log("entered Transition bool is " + enteredTransition);

            if (collision.CompareTag("Player"))
            {
                playerMovingToPosition = true;
                Debug.Log("player moving to position is " + playerMovingToPosition);
                cameraTransitions.cinemachineTargetPos = cinemachineTargetPos;
                cameraTransitions.playerTargetPos = playerTargetPos;

            }
        }
        //Debug.Log("hit line collider");
        //enteredTransition = true;
        //Debug.Log("entered Transition bool is " + enteredTransition);

        //if (collision.CompareTag("Player"))
        //{
        //    playerMovingToPosition = true;
        //    Debug.Log("player moving to position is " + playerMovingToPosition);
        //    cameraTransitions.cinemachineTargetPos = cinemachineTargetPos;
        //    cameraTransitions.playerTargetPos = playerTargetPos;

        //}
    }
}
