using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterChoose : MonoBehaviour
{
	public static int chooseCharacter;
	[SerializeField] private GameObject character1;
	[SerializeField] private GameObject character2;
	[SerializeField] private GameObject character3;
	
	public static int chooseMap;
	[SerializeField] private GameObject bg;
	private SpriteRenderer bg0;
	[SerializeField] private Sprite bg1;
	[SerializeField] private Sprite bg2;
	
    void Start()
    {
		bg0 = bg.GetComponent<SpriteRenderer>();
		
        switch (chooseCharacter)
		{
			case 0:
				character1.SetActive(true);
				break;
			case 1:
				character2.SetActive(true);
				break;
			case 2:
				character3.SetActive(true);
				break;
			default:
				Debug.Log("character summon error");
				break;
		}
		
		switch (chooseMap)
		{
			case 0:
				bg0.sprite = bg1;
				break;
			case 1:
				bg0.sprite = bg2;
				break;
			default:
				Debug.Log("map summon error");
				break;
		}
    }
}
