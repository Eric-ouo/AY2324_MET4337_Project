using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGoalInteraction : MonoBehaviour
{

    public float dragIncrease = 10f;
    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Ball"))
        {
            Rigidbody2D ballRigidbody = other.GetComponent<Rigidbody2D>();
            if (ballRigidbody != null)
            {
                ballRigidbody.drag += dragIncrease;
            }
            if (transform.position.x < 0f)
            {
                Debug.Log("right");
                AudioManager.instance.PlayWin();
                scoreManager.IncreaseRightScore();
            }
            else if (transform.position.x > 0f)
            {
                Debug.Log("Left");
                AudioManager.instance.PlayWin();
                scoreManager.IncreaseLeftScore();
            }
        }
    }
}