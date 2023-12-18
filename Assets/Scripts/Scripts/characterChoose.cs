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
				Instantiate(character1, new Vector3(-5f, -2f, 0), Quaternion.identity);
				break;
			case 1:
				Instantiate(character2, new Vector3(-5f, -2f, 0), Quaternion.identity);
				break;
			case 2:
				Instantiate(character3, new Vector3(-5f, -2f, 0), Quaternion.identity);
				break;
			default:
				Debug.Log("character summon error");
				break;
		}
    }
}
