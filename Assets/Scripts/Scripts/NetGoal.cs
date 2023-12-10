using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetGoal : MonoBehaviour
{
    // This tag should match the tag set on your soccer ball GameObject.
    public string ballTag = "SoccerBall";

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object colliding with the net has the correct tag.
        if (other.CompareTag(ballTag))
        {
            // Call the AddScore method from the ScoreManager to add one point.
            ScoreManager.AddScore(1);
        }
    }
}
