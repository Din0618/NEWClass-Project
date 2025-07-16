using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
	public GameManager Manager;
	public GameObject dude;
    void OnTriggerEnter(Collider other)
	{
		if(other.gameObject == dude)
		{
			// emd the game
			Debug.Log("help");
			Manager.endGame();

		}
	}

}