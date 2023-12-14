using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip hitboard;
    public AudioClip hitground;
    public AudioClip hitnet;
    public AudioClip kickground;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayHitBoard()
    {
        audioSource.PlayOneShot(hitboard);
    }

    public void PlayHitGround()
    {
        audioSource.PlayOneShot(hitground);
    }

    public void PlayHitNet()
    {
        audioSource.PlayOneShot(hitnet);
    }

    public void PlayKickGround()
    {
        audioSource.PlayOneShot(kickground);
    }
}