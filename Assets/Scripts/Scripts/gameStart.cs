using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameStart : MonoBehaviour
{
	public void start()
	{
		SceneManager.LoadScene(1);
	}
	
	public void settings()
	{
		
	}
	
	public void quit()
	{
		Application.Quit();
	}
}
