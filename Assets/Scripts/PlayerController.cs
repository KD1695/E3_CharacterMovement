using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator animator;

    bool isJumping = false;

    void Start()
    {
        GameState.State.setIdleState += OnIdleState;
        GameState.State.setWalkingState += OnPlayerWalking;
        GameState.State.setJumpingState += OnPlayerJumping;
        GameState.State.setRunningState += OnPlayerRunning;
    }

    private void LateUpdate()
    {
        if(isJumping)
        {
            if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            {
                isJumping = false;
                GameState.State.SetJumpState(false);
            }
        }    
    }

    void OnIdleState()
    {
        animator.SetBool("isRunning", false);
        animator.SetBool("isJumping", false);
        animator.SetBool("isWalking", false);
    }

    void OnPlayerWalking()
    {
        animator.SetBool("isRunning", false);
        animator.SetBool("isJumping", false);
        animator.SetBool("isWalking", true);
    }

    void OnPlayerJumping()
    {
        animator.SetBool("isRunning", false);
        animator.SetBool("isWalking", false);
        animator.SetBool("isJumping", true);
        isJumping = true;
    }

    void OnPlayerRunning()
    {
        animator.SetBool("isJumping", false);
        animator.SetBool("isWalking", true);
        animator.SetBool("isRunning", true);
    }
}
