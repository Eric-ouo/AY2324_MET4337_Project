using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
	public bool ballIn;
	
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ball"))
        {
			ballIn = true;
            Debug.Log("goal");
        }
    }
}
