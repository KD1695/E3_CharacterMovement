using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] CapsuleCollider collider;
    [SerializeField] Transform bonesRoot;

    bool isJumping = false;
    bool isRolling = false;
    float lookSpeed = 5.0f;

    float oldBoneHeight;

    private void Awake()
    {
        oldBoneHeight = bonesRoot.transform.position.y;
    }

    void Start()
    {
        GameState.State.setIdleState += OnIdleState;
        GameState.State.setWalkingState += OnPlayerWalking;
        GameState.State.setJumpingState += OnPlayerJumping;
        GameState.State.setRunningState += OnPlayerRunning;
        GameState.State.setRollingState += OnPlayerRolling;
        GameState.State.setAttackingState += OnPlayerAttack;
    }

    private void Update()
    {
        float diff = bonesRoot.transform.position.y - oldBoneHeight;
        oldBoneHeight = bonesRoot.transform.position.y;
        collider.center = new Vector3(0, collider.center.y+diff, 0);
        float mouseInput = Input.GetAxis("Mouse Y");
        Vector3 lookhere = new Vector3(0, mouseInput * lookSpeed, 0);
        transform.Rotate(lookhere);
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
        if (isRolling)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            {
                isRolling = false;
                GameState.State.SetRollingState(false);
            }
        }
    }

    void OnIdleState()
    {
        animator.SetBool("isRunning", false);
        animator.SetBool("isJumping", false);
        animator.SetBool("isWalking", false);
        animator.SetBool("isRolling", false);
        animator.SetBool("isAttacking", false);
    }

    void OnPlayerWalking()
    {
        animator.SetBool("isRunning", false);
        animator.SetBool("isJumping", false);
        animator.SetBool("isRolling", false);
        animator.SetBool("isAttacking", false);
        animator.SetBool("isWalking", true);
    }

    void OnPlayerJumping()
    {
        animator.SetBool("isRunning", false);
        animator.SetBool("isWalking", false);
        animator.SetBool("isRolling", false);
        animator.SetBool("isAttacking", false);
        animator.SetBool("isJumping", true);
        isJumping = true;
    }

    void OnPlayerRolling()
    {
        animator.SetBool("isRunning", false);
        animator.SetBool("isWalking", false);
        animator.SetBool("isJumping", false);
        animator.SetBool("isAttacking", false);
        animator.SetBool("isRolling", true);
        isRolling = true;
    }

    void OnPlayerRunning()
    {
        animator.SetBool("isJumping", false);
        animator.SetBool("isRolling", false);
        animator.SetBool("isAttacking", false);
        animator.SetBool("isWalking", true);
        animator.SetBool("isRunning", true);
    }

    void OnPlayerAttack()
    {
        animator.SetBool("isJumping", false);
        animator.SetBool("isRolling", false);
        animator.SetBool("isWalking", false);
        animator.SetBool("isRunning", false);
        animator.SetBool("isAttacking", true);
    }
}
