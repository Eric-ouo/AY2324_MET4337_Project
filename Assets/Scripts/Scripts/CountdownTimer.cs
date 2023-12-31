using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public int countdownTime = 60; // Countdown from 60 seconds
    public Text countdownDisplay; // Reference to UI Text element
    public GameObject losePanel; // Reference to the Lose panel
    
    private void Start()
    {
        if (countdownDisplay == null || losePanel == null)
        {
            Debug.LogError("UI references not set on CountdownTimer script.");
            return;
        }

        losePanel.SetActive(false); // Ensure the lose panel is hidden at the start

        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        while (countdownTime > 0)
        {
            countdownDisplay.text = string.Format("{0:00}:{1:00}", countdownTime / 60, countdownTime % 60);
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }

        countdownDisplay.text = "00:00";
        OnCountdownFinished(); // Call the method to handle the end of the countdown
    }

    void OnCountdownFinished()
    {
        losePanel.SetActive(true); // Show the lose panel
        // Wait for a short while before showing the pause panel
        StartCoroutine(ShowPausePanelAfterDelay(1f)); // 1 second delay for example
    }

    IEnumerator ShowPausePanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Time.timeScale = 0f; // Pause the game
    }

    public void ExitGame() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); 
    }
	
	public void pauseButtonClick(bool click)
	{
		if (click)
		{
			Time.timeScale = 0f;
		}
		else
		{
			Time.timeScale = 1f;
		}
	}
}