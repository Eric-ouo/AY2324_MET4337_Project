using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score : MonoBehaviour
{
    public ScoreManager scoreManager;
    [SerializeField] TextMeshProUGUI leftScoreUI;
    [SerializeField] TextMeshProUGUI rightScoreUI;

    void Start()
    {
        UpdateScore();
    }

    void Update()
    {
        UpdateScore();
    }
    void UpdateScore()
    {
        leftScoreUI.text = scoreManager.leftscore.ToString();
        rightScoreUI.text = scoreManager.rightscore.ToString();
    }
}
