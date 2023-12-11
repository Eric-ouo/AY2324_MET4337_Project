using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score : MonoBehaviour
{
    public int playerScore;
	[SerializeField] TextMeshProUGUI scoreUI;
	
    void Start()
    {
        
    }

    void Update()
    {
        scoreUI.text = playerScore.ToString();
    }
}
