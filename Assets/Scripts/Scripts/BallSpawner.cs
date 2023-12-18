using UnityEngine;
using System.Collections;

public class BallSpawner : MonoBehaviour
{
    public GameObject BallPrefab; // Assign your ball prefab in the Inspector
    private int ballCount = 0;
    private int maxBalls = 10;

    private void Start()
    {
        StartCoroutine(SpawnBallEveryFiveSeconds());
    }

    IEnumerator SpawnBallEveryFiveSeconds()
    {
        while (ballCount < maxBalls)
        {
            SpawnBall();
            yield return new WaitForSeconds(5f);
        }
    }

    void SpawnBall()
    {
        Instantiate(BallPrefab, transform.position, Quaternion.identity);
        ballCount++;
    }
}