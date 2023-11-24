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
	}
}
