using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    [SerializeField] Animator animator;
    private string lastExecutedAnimation = string.Empty;

    void Start()
    {
        AbilityIcon.setCurrentAttack += HandleAttack;
    }

    void Update()
    {
        if (lastExecutedAnimation != string.Empty && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            animator.SetBool(lastExecutedAnimation, false);
            lastExecutedAnimation = string.Empty;
        }
    }

    public void HandleAttack(string animatorBoolString)
    {
        animator.SetBool(animatorBoolString, true);
        lastExecutedAnimation = animatorBoolString;
    }
}
