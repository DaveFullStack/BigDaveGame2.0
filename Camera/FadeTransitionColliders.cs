using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTransitionColliders : MonoBehaviour
{
    private FadeCameraTransition fadeCameraTransition;
    //public GameObject canvasToSetActive;

    public Vector3 cinemachineTargetPosition;
    public Vector2 walkOffScreenTargetPos;

    public Vector2 walkOnScreenStartPosition;
    public Vector2 walkOnScreenTargetPosition;



    private void Start()
    {
        fadeCameraTransition = FindObjectOfType<FadeCameraTransition>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!fadeCameraTransition.InTransition)
        {
            fadeCameraTransition.InTransition = true;
            //canvasToSetActive.SetActive(true);
            Debug.Log($"inTransition bool is {fadeCameraTransition.InTransition}");
        }
        
        else
        {
            return;
            
        }
    }
}
