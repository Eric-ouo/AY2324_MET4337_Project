using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGoalInteraction : MonoBehaviour
{

    public float dragIncrease = 10f;
    private ScoreManager scoreManager;
    public AudioManager audioManager;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        audioManager = AudioManager.instance;//
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
                scoreManager.IncreaseRightScore();
                audioManager.PlayWin();//
            }
            else if (transform.position.x > 0f)
            {
                Debug.Log("Left");
                scoreManager.IncreaseLeftScore();
                audioManager.PlayWin();//
            }
        }
    }
}