using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scorePve : MonoBehaviour
{
	[SerializeField] private int score;
	[SerializeField] private TextMeshProUGUI scoreUI;
	[SerializeField] private GameObject ball;
	
	void Update()
	{
		scoreUI.text = score.ToString();
	}
	
	private void OnTriggerEnter2D(Collider2D other)
    {
		if (other.CompareTag("Bullet"))
        {
			Destroy(other.gameObject);
			Instantiate(ball, new Vector3(0f, -0.42f, 0f), Quaternion.identity);
            score++;
        }
	}
}
