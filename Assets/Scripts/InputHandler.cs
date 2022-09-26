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
            GameState.State.SetWalkState(true);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            GameState.State.SetJumpState(true);
        }
        if(!Input.anyKey)
        {
            GameState.State.SetIdleState(true);
        }
    }
}
