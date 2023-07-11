using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransitionColliders : MonoBehaviour
{
    private CameraTransitions cameraTransitions;
    public Vector3 cinemachineTargetPos;

    

    private bool enteredTransition;

    private void Start()
    {
        cameraTransitions = FindObjectOfType<CameraTransitions>();
        enteredTransition = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(!enteredTransition)
        {
            if (collision.CompareTag("Player"))
            {
                enteredTransition = true;
                cameraTransitions.cinemachineTargetPos = cinemachineTargetPos;
            }
        }
    }
}
