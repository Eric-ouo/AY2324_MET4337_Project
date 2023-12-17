using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RunFootstepSoundPlayer : MonoBehaviour
{
    // The footstep sound clip to play.
    public AudioClip footstepSound;

    // Reference to the AudioSource component.
    private AudioSource audioSource;

    // Reference to the Animator component.
    private Animator animator;

    // The name of the running state in the Animator.
    [SerializeField] private string runningStateName = "IsRunning";

    private void Start()
    {
        // Get the AudioSource and Animator components attached to the GameObject.
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        // Check if the character is in the running state.
        if (animator.GetBool(runningStateName))
        {
            // If the character is running and the footstep sound isn't playing, play the sound.
            if (!audioSource.isPlaying)
            {
                audioSource.clip = footstepSound;
                audioSource.loop = true; // Loop the sound
                audioSource.Play();
            }
        }
        else
        {
            // If the character is not running, stop the footstep sound if it's playing.
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}