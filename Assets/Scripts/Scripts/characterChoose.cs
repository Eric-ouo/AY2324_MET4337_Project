using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterChoose : MonoBehaviour
{
	public static int chooseCharacter;
	[SerializeField] private GameObject character1;
	[SerializeField] private GameObject character2;
	[SerializeField] private GameObject character3;
	
    void Start()
    {
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
    }
}
