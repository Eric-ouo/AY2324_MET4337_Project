using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int leftScore = 0;
    public int rightScore = 0;

    // References to the player GameObjects
    public GameObject leftPlayer;
    public GameObject rightPlayer;

    // Reference to the ball GameObject
    [SerializeField] private GameObject ball;

    // Private variables to store the new start positions
    private Vector3 leftPlayerNewStartPosition = new Vector3(-6.63000011f, 4.23999977f, 0.0444346517f);
    private Vector3 rightPlayerNewStartPosition = new Vector3(3.52999997f, 4.3499999f, 0.0444346517f);

    private void Start()
    {
        if (ball == null)
        {
            Debug.LogError("Ball is not set in the inspector!");
        }

        // Reset players and ball to their start positions
        ResetMatch();
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
        // Reset and move the left player
        if (leftPlayer != null)
        {
            leftPlayer.transform.position = Vector3.zero; // Reset position to zero first
            leftPlayer.transform.position = leftPlayerNewStartPosition; // Then set to new start position
            Debug.Log("Left player has been moved to the start position: " + leftPlayerNewStartPosition);
        }
        else
        {
            Debug.LogError("Left player is not found in the scene.");
        }

        // Reset and move the right player
        if (rightPlayer != null)
        {
            rightPlayer.transform.position = Vector3.zero; // Reset position to zero first
            rightPlayer.transform.position = rightPlayerNewStartPosition; // Then set to new start position
            Debug.Log("Right player has been moved to the start position: " + rightPlayerNewStartPosition);
        }
        else
        {
            Debug.LogError("Right player is not found in the scene.");
        }
    }

    private void ResetBall()
    {
        if (ball != null)
        {

            ball.transform.position = Vector3.zero;

            Rigidbody2D ballRigidbody = ball.GetComponent<Rigidbody2D>();
            if (ballRigidbody != null)
            {
   
                ballRigidbody.velocity = Vector2.zero;
                ballRigidbody.angularVelocity = 0;

                ballRigidbody.drag = 0.1f;
            }
            else
            {
                Debug.LogError("Ball Rigidbody2D component missing.");
            }
        }
        else
        {
            Debug.LogError("Ball GameObject is null. Cannot reset ball position.");
        }
    }
}