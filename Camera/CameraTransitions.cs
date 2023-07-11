using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraTransitions : MonoBehaviour
{

    public GameObject cinemachine;
    public Vector3 cinemachineTargetPos;
    

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
        cinemachine.transform.position = cinemachineTargetPos;
    }
}
