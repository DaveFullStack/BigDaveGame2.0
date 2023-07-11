using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraTransitions : MonoBehaviour
{
    public GameObject player;
    public GameObject cinemachine;
    public Vector3 cinemachineTargetPos;

    public float cameraMoveSpeed = 5f;
    

    // Update is called once per frame
    void Update()
    {
        if(cinemachine.transform.position != cinemachineTargetPos)
        {
            MoveCamera();
        }
    }

    public void MoveCamera()
    {
        Vector3 movementDirection = (cinemachineTargetPos - cinemachine.transform.position).normalized;
        Vector3 movement = movementDirection * cameraMoveSpeed * Time.fixedDeltaTime;
        cinemachine.transform.position += movement;
        if(Vector3.Distance(cinemachine.transform.position, cinemachineTargetPos) <= 0.5f)
        {
            cinemachine.transform.position = cinemachineTargetPos;
        }
    }
}
