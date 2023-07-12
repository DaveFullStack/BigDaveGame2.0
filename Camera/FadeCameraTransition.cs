using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeCameraTransition : MonoBehaviour
{
    public bool InTransition;
    public CanvasGroup canvasGroup;
    public GameObject canvasToSetActive;

    private void Update()
    {
        
    }

    /* When InTRansition Bool is True start Coroutine
     * Set CanvasToSetActive to true
     * Set canvasGroup Alpha to 0 so the Image is not visible.
     * Start FadeIn Animation
     * When FadeIn Animation ends move the camera to the target position. Variable Vector3 to be set in FadeTransitionColliders.
     * Set player GameObject to target position. Variable to be set in public Vector2 in FadeTransitionColliders.
     * 
     *
     * 
     */
    
}
