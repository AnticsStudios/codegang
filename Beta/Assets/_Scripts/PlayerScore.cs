using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {
	public int playerScore = 0;
	public GameObject playerScoreUI;

	void Update()
	{
		playerScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + playerScore);	
	}

	void OnTriggerEnter2D(Collider2D trig)
	{
		if (trig.gameObject.name == "Enemy")
		{
			Score();
			Destroy(trig.gameObject);
		}
	}

    void Score()
	{
		playerScore =  playerScore + 10;
	}
}
