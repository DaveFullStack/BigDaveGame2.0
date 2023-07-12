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

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        fadeTransitionColliders = FindObjectOfType<FadeTransitionColliders>();
        playerController = FindObjectOfType<PlayerController>();
    }

    private void FixedUpdate()
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
        playerController.canControlMovement = false;
        canvasAnimator.SetBool("StartFadeIn", true);
        Debug.Log($"canvasAnimator bool startFadeIn is {canvasAnimator.GetBool("StartFadeIn")}");
        PlayerWalkOffScreen();

        yield return new WaitForSeconds(canvasAnimator.GetCurrentAnimatorStateInfo(0).length);

        Debug.Log($"Cinemachine Transform before movement is {cinemachineCameraPos.position.ToString()}");
        cinemachineCameraPos.position = fadeTransitionColliders.cinemachineTargetPosition;
        Debug.Log($"Cinemachine Transform position after movement is {cinemachineCameraPos.position.ToString()}");

        



        //canvasAnimator.SetBool("StartFadeIn", false);
        //canvasAnimator.SetBool("StartFadeOut", true);

        



    }

    private void PlayerWalkOffScreen()
    {
        Rigidbody2D playerRigidbody = player.GetComponent<Rigidbody2D>();
        Vector2 moveDirection = playerRigidbody.position - fadeTransitionColliders.walkOffScreenTargetPos.normalized;
        Vector2 movement = moveDirection * playerMoveSpeedInTransition * Time.fixedDeltaTime;
        playerRigidbody.position += movement;

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
