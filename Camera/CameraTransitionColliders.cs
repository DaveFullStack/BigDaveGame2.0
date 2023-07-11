using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransitionColliders : MonoBehaviour
{
    public Vector2 cinemachineTargetPos;
    public CameraTransitions cameraTransitions;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cameraTransitions.cinemachineTargetPos = cinemachineTargetPos;
        }
    }
}
