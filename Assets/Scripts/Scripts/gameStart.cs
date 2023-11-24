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
	
	void Start()
	{
		anim = canvas.GetComponent<Animator>();
	}
	
	void Update()
	{
		soundValue = (int)slider.value;
	}
	
	public void start_game()
	{
		SceneManager.LoadScene(1);
	}
	
	public void entry_settings()
	{
		anim.SetBool("settings", true);
	}
	
	public void exit_settings()
	{
		anim.SetBool("settings", false);
	}
	
	public void quit()
	{
		Application.Quit();
	}
}
