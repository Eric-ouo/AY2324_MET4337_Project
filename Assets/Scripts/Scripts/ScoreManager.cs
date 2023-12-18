using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int leftScore = 0;
    public int rightScore = 0;

    // Start positions for ball and players
    public Transform leftPlayerStartPosition;
    public Transform rightPlayerStartPosition;
    public Transform ballStartPosition; 
    
    // References to the player and ball GameObjects
    public GameObject leftPlayer;
    public GameObject rightPlayer;
    [SerializeField] private GameObject ball; 

    private void Start()
    {
        // Ensure that ballStartPosition and ball are set
        if (ballStartPosition == null)
        {
            Debug.LogError("Ball Start Position is not set in the inspector!");
        }

        if (ball == null)
        {
            Debug.LogError("Ball is not set in the inspector!");
        }
    }

    public void IncreaseRightScore()
    {
        rightScore++;
        ResetMatch();
    }

    public void IncreaseLeftScore()
    {
        leftScore++;
        ResetMatch();
    }

    private void ResetMatch()
    {
        ResetPlayers();
        ResetBall();
    }

    private void ResetPlayers()
    {
        // Ensure the players are not null before trying to reset their positions
        if (leftPlayer != null && rightPlayer != null)
        {
            leftPlayer.transform.position = leftPlayerStartPosition.position;
            rightPlayer.transform.position = rightPlayerStartPosition.position;
        }
        else
        {
            Debug.LogError("One or both player GameObjects are missing.");
        }
    }

    private void ResetBall()
    {
        if (ball != null && ballStartPosition != null)
        {
            ball.transform.position = ballStartPosition.position;

            Rigidbody2D ballRigidbody = ball.GetComponent<Rigidbody2D>();
            if (ballRigidbody != null)
            {
                ballRigidbody.velocity = Vector2.zero;
                ballRigidbody.angularVelocity = 0;
            }
            else
            {
                Debug.LogError("Ball Rigidbody2D component missing.");
            }
        }
        else
        {
            if (ball == null)
            {
                Debug.LogError("Ball GameObject is null. Cannot reset ball position.");
            }
            if (ballStartPosition == null)
            {
                Debug.LogError("Ball start position is null. Cannot reset ball position.");
            }
        }
          GameObject player = GameObject.FindWithTag("Player"); // Make sure your player has the tag "Player"
    if (player != null)
    {
        PlayerController playerController = player.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.RespawnAfterGoal();
        }
    }
    }
}