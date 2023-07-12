using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeCameraTransition : MonoBehaviour
{
    public bool InTransition;
    public CanvasGroup canvasGroup;
    public GameObject canvasToSetActive;
    public Animator canvasAnimator;

    private FadeTransitionColliders fadeTransitionColliders;

    private void Start()
    {
        fadeTransitionColliders = FindObjectOfType<FadeTransitionColliders>();
    }

    private void Update()
    {

        if (InTransition)
        {
            canvasToSetActive.SetActive(true);
            canvasGroup.alpha = 0;
            Debug.Log($"canvas to set active is {canvasToSetActive.activeInHierarchy}\n" +
                $"canvasGroup alpha is {canvasGroup.alpha.ToString()}");

            StartCoroutine(PlayFadeTransition());
        }
        
    }

    IEnumerator PlayFadeTransition()
    {
        canvasAnimator.SetBool("StartFadeIn", true);
        Debug.Log($"canvasAnimator bool startFadeIn is {canvasAnimator.GetBool("StartFadeIn")}");
        yield return new WaitForSeconds(canvasAnimator.GetCurrentAnimatorStateInfo(0).length);

        canvasAnimator.SetBool("StartFadeIn", false);
        canvasAnimator.SetBool("StartFadeOut", true);

        



    }

    

    /* When InTransition Bool is True start Coroutine
     * Set CanvasToSetActive to true
     * Set canvasGroup Alpha to 0 so the Image is not visible.
     * Start FadeIn Animation
     * When FadeIn Animation ends move the camera to the target position. Variable Vector3 to be set in FadeTransitionColliders.
     * Set player GameObject to start position. Variable to be set in public Vector2 in FadeTransitionColliders.
     * Start FadeOut Animation
     * As Fade out animation plays the player GameObject moves from start position to target position.
     * Set bool for player animator isWalking to true so the walking animation plays
     * set bool for canControlMovement in playerController to false so player cannot control the movement of the player gameObject.
     * 
     */
    
}
