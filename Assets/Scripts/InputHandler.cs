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
        else
        {
            GameState.State.SetIdleState(true);
        }
    }
}
