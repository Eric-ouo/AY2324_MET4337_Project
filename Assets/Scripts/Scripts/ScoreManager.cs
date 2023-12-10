using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Static variable for the score, accessible from other scripts without a reference.
    public static int score = 0;

    // Static method to add points to the score. Can be called from any other script.
    public static void AddScore(int value)
    {
        score += value;
        // Optional: Print the new score to the console for debugging.
        Debug.Log("Score added! Current score: " + score);
    }

    // Awake is called when the script instance is being loaded.
    void Awake()
    {
        // Reset score to zero when the game starts/restarts.
        score = 0;
    }
}