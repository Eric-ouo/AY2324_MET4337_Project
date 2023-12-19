using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scorePve : MonoBehaviour
{
	[SerializeField] private int score;
	[SerializeField] private TextMeshProUGUI scoreUI;
	[SerializeField] private GameObject ball;
	public AudioManager audioManager;//
	
	void Start()
	{
		audioManager = AudioManager.instance;//
	}

	void Update()
	{
		scoreUI.text = score.ToString();
	}
	
	private void OnTriggerEnter2D(Collider2D other)
    {
		if (other.CompareTag("Bullet"))
        {
			audioManager.PlayWater();//
            Destroy(other.gameObject);
			Instantiate(ball, new Vector3(0f, -0.42f, 0f), Quaternion.identity);
            score++;
        }
	}
}
