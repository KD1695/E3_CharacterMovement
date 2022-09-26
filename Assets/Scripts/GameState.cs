using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState State; 
    bool iswalking = false, isRunning = false, isJumping = false, isRolling = false;

    public event Action setIdleState;
    public event Action setWalkingState;
    public event Action setJumpingState;
    public event Action setRunningState;
    public event Action setRollingState;

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
        if((!iswalking && _isWalking) || isRunning)
        {
            iswalking = _isWalking;
            isRunning = false;
            setWalkingState();
        }
    }

    public void SetJumpState(bool _isJumping)
    {
        if (!isJumping && _isJumping)
        {
            isJumping = _isJumping;
            iswalking = false;
            isRunning = false;
            setJumpingState();
        }
        else if(!_isJumping)
        {
            isJumping = false;
        }
    }

    public void SetRunningState(bool _isRunning)
    {
        if (!isRunning && _isRunning)
        {
            isRunning = _isRunning;
            setRunningState();
        }
    }

    public void SetRollingState(bool _isRolling)
    {
        if (!isRolling && _isRolling)
        {
            isRolling = _isRolling;
            iswalking = false;
            isRunning = false;
            setRollingState();
        }
        else if (!_isRolling)
        {
            isRolling = false;
        }
    }
}
