using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameStart : MonoBehaviour
{
	[SerializeField] private GameObject canvas;
	[SerializeField] private Animator anim;
	
	[SerializeField] private Slider slider;
	[SerializeField] private int soundValue;
	
	[SerializeField] private AudioManager audioManager;
	
	void Start()
	{
		anim = canvas.GetComponent<Animator>();
		audioManager = AudioManager.instance;
	}
	
	void Update()
	{
		soundValue = (int)slider.value;
		playerSerrings.soundValue = soundValue;
        audioManager.backgroundMusicSource.volume = (float)soundValue / 10;
        audioManager.soundEffectsSource.volume = (float)soundValue / 2;
    }
	
	public void start_game()
	{
        audioManager.PlayButtonClick();
        SceneManager.LoadScene(1);
	}
	
	public void entry_settings()
	{
        audioManager.PlayButtonClick();
        anim.SetBool("settings", true);
    }
	
	public void exit_settings()
	{
        audioManager.PlayButtonClick();
        anim.SetBool("settings", false);
    }
	
	public void quit()
	{
        audioManager.PlayButtonClick();
        Application.Quit();
    }
}
