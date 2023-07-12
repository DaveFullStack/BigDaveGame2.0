using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeCameraTransition : MonoBehaviour
{
    public bool InTransition;
    public CanvasGroup canvasGroup;
    public GameObject canvasToSetActive;
    public Animator canvasAnimator;

    public Transform cinemachineCameraPos;

    public float playerMoveSpeedInTransition;

    private FadeTransitionColliders fadeTransitionColliders;

    private PlayerController playerController;
    private GameObject player;
    private Animator playerAnimator;

    public Vector3 cinemachineTargetPos;
    public Vector2 playerSpawnPosition;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        fadeTransitionColliders = FindObjectOfType<FadeTransitionColliders>();
        playerController = FindObjectOfType<PlayerController>();
    }

    private void FixedUpdate()
    {

        if (InTransition)
        {
            StartCoroutine(PlayFadeTransition());
        }
        else
        {
            return;
        }
        
    }

    IEnumerator PlayFadeTransition()
    {
        canvasToSetActive.SetActive(true);
        canvasGroup.alpha = 0;
        //Debug.Log($"canvas to set active is {canvasToSetActive.activeInHierarchy}\n" +
        //$"canvasGroup alpha is {canvasGroup.alpha.ToString()}");
        playerController.canControlMovement = false;

        canvasAnimator.SetBool("StartFadeIn", true);
        Debug.Log($"canvasAnimator bool startFadeIn is {canvasAnimator.GetBool("StartFadeIn")}");

        playerAnimator.SetBool("isMoving", false);

        yield return new WaitForSeconds(canvasAnimator.GetCurrentAnimatorStateInfo(0).length);

        Debug.Log($"Cinemachine Transform before movement is {cinemachineCameraPos.position.ToString()}");
        cinemachineCameraPos.position = cinemachineTargetPos;
        Debug.Log($"Cinemachine Transform position after movement is {cinemachineCameraPos.position.ToString()}");

        player.GetComponent<Rigidbody2D>().position = playerSpawnPosition;

        yield return new WaitForSeconds(0.5f);
        
        canvasAnimator.SetBool("StartFadeIn", false);
        canvasAnimator.SetBool("StartFadeOut", true);

        InTransition = false;
        playerController.canControlMovement = true;

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
