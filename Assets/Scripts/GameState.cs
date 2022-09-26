using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState State; 
    bool iswalking = false, isRunning = false, isJumping = false, isSpinning = false;

    public event Action setIdleState;
    public event Action setWalkingState;
    public event Action setJumpingState;

    private void Awake()
    {
        State = this;
    }

    public void SetIdleState(bool _idleState)
    {
        iswalking = false;
        isJumping = false;
        setIdleState();
    }

    public void SetWalkState(bool _isWalking)
    {
        if(!iswalking && _isWalking)
        {
            iswalking = _isWalking;
            setWalkingState();
        }
    }

    public void SetJumpState(bool _isJumping)
    {
        if (!isJumping && _isJumping)
        {
            isJumping = _isJumping;
            iswalking = false;
            setJumpingState();
        }
        else if(!_isJumping)
        {
            isJumping = false;
        }
    }

    public void SetRunningState()
    {

    }

    public void SetJumpState()
    {

    }

    public void SetSpinState()
    {

    }
}
