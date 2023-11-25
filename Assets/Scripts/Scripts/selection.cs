using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selection : MonoBehaviour
{
	[SerializeField] private GameObject canvas;
	[SerializeField] private Animator anim;
	
	[SerializeField] private int character;
	[SerializeField] private int map;
	
	void Start()
	{
		anim = canvas.GetComponent<Animator>();
	}
	
	public void back()
	{
		if (anim.GetBool("map"))
		{
			anim.SetBool("map", false);
		}
		else
		{
			SceneManager.LoadScene(0);
		}
	}
	
	public void chooseCharacter(int i)
	{
		character = i;
		anim.SetBool("map", true);
	}
	
	public void chooseMap(int i)
	{
		map = i;
		playerSerrings.characterSelect = character;
		playerSerrings.mapSelect = map;
		
		
		switch (playerSerrings.mapSelect)
		{
			case 0:
				SceneManager.LoadScene(2);
				break;
			case 1:
				SceneManager.LoadScene(3);
				break;
			default:
				Debug.Log("map select error");
				break;
		}
	}
}