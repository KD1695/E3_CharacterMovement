using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip jumpClip;
    [SerializeField] AudioClip footstepsWalkClip;
    [SerializeField] AudioClip footstepsRunClip;

    bool stopAfterPlay = false;

    void Start()
    {
        GameState.State.setIdleState += OnIdleState;
        GameState.State.setWalkingState += OnPlayerWalking;
        GameState.State.setJumpingState += OnPlayerJumping;
        GameState.State.setRunningState += OnPlayerRunning;
    }

    private void Update()
    {
        if(stopAfterPlay)
        {
            if(!audioSource.isPlaying)
            {
                audioSource.Stop();
                audioSource.clip = null;
                audioSource.loop = false;
            }
        }
    }

    private void OnPlayerRunning()
    {
        audioSource.clip = footstepsRunClip;
        audioSource.loop = true;
        audioSource.Play();
    }

    private void OnPlayerJumping()
    {
        audioSource.clip = jumpClip;
        audioSource.loop = false;
        audioSource.Play();
    }

    private void OnPlayerWalking()
    {
        audioSource.clip = footstepsWalkClip;
        audioSource.loop = true;
        audioSource.Play();
    }

    private void OnIdleState()
    {
        if(audioSource.loop)
        {
            audioSource.Stop();
            audioSource.clip = null;
            audioSource.loop = false;
            stopAfterPlay = false;
        }
        else
            stopAfterPlay = true;
    }
}
