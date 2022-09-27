using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
                GameState.State.SetRunningState(true);
            else
                GameState.State.SetWalkState(true);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            GameState.State.SetJumpState(true);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            GameState.State.SetRollingState(true);
        }
        if(Input.GetKey(KeyCode.Mouse0))
        {
            GameState.State.SetAttackState(true);
        }
        if (!Input.anyKey)
        {
            GameState.State.SetIdleState(true);
        }
    }
}
