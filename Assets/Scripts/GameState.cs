using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState State; 
    bool iswalking, isRunning, isJumping, isSpinning = false;

    public event Action setIdleState;
    public event Action setWalkingState;

    private void Awake()
    {
        State = this;
    }

    public void SetIdleState(bool _idleState)
    {
        iswalking = false;
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
