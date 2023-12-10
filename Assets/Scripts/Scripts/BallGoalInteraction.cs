using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGoalInteraction : MonoBehaviour
{

    public float dragIncrease = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Bullet"))
        {
            Rigidbody2D ballRigidbody = other.GetComponent<Rigidbody2D>();
            if (ballRigidbody != null)
            {
                ballRigidbody.drag += dragIncrease;
            }
        }
    }
}