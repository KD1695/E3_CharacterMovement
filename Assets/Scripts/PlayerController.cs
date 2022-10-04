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
    }

    private void Update()
    {
        float diff = bonesRoot.transform.position.y - oldBoneHeight;
        oldBoneHeight = bonesRoot.transform.position.y;
        collider.center = new Vector3(0, collider.center.y+diff, 0);
        if(Input.GetKey(KeyCode.A))
        {
            Vector3 lookhere = new Vector3(0, -0.1f * lookSpeed, 0);
            transform.Rotate(lookhere);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            Vector3 lookhere = new Vector3(0, 0.1f * lookSpeed, 0);
            transform.Rotate(lookhere);
        }
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

    void OnDestroy()
    {
        GameState.State.setIdleState -= OnIdleState;
        GameState.State.setWalkingState -= OnPlayerWalking;
        GameState.State.setJumpingState -= OnPlayerJumping;
        GameState.State.setRunningState -= OnPlayerRunning;
    }
}
