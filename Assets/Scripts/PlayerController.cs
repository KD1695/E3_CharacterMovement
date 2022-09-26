using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator animator;

    void Start()
    {
        GameState.State.setIdleState += OnIdleState;
        GameState.State.setWalkingState += OnPlayerWalking;
    }

    private void Update()
    {
        
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

}
