using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{

	public GameObject playerScoreUI;
	private int playerScore; //= PlayerPrefs.GetInt("playerTotalScore");


	void Update()
	{
        
        //print UI to screen
		playerScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + playerScore);	
	}
    //check 2D trigger / collision
	void OnTriggerEnter2D(Collider2D trig)
	{
        //if tag is enemy, call score basic for now 
        if (trig.gameObject.tag == "Enemy")
        {
			//MovePlayer isAboveEnemy = GetComponent<MovePlayer>();

            //call score function
            //if (isAboveEnemy == true)
            //{
                Score(50);
            //}
        }
	}

    void Score(int amountOfPoints)
    {
		//add score 
		playerScore += amountOfPoints;
		PlayerPrefs.SetInt("playerTotalScore", playerScore);
    }
}

