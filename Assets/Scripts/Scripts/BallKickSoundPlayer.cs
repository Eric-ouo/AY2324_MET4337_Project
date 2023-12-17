using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BallKickSoundPlayer : MonoBehaviour
{
    // The sound clip that will be played when the ball is kicked.
    public AudioClip kickSound;

    // Reference to the AudioSource component.
    private AudioSource audioSource;

    private void Start()
    {
        // Initialize the AudioSource component.
        audioSource = GetComponent<AudioSource>();
    }

    // This method will be called by the physics engine when the ball collides with another object.
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the player's foot.
        // We assume that the player's foot has a tag named "PlayerFoot".
        if (collision.collider.CompareTag("PlayerFoot"))
        {
            // Play the kick sound.
            audioSource.PlayOneShot(kickSound);
        }
        if (collision.collider.CompareTag("Ground"))
        {
            // Play the kick sound.
            audioSource.PlayOneShot(kickSound);
        }
    }
}