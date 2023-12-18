using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int leftscore = 0;
    public int rightscore = 0;

    public void IncreaseRightScore()
    {
        rightscore++;
    }
    public void IncreaseLeftScore()
    {
        leftscore++;
    }
}