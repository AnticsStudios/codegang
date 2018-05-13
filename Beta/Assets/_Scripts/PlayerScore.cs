using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
	public int playerScore = 0;
	public GameObject playerScoreUI;


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
            PlayerPrefs.GetInt("CharacterSelected");
            
            MovePlayer isAboveEnemy = GetComponent<MovePlayer>();
            //call score function
            if (isAboveEnemy == true)
            {
                Debug.Log(isAboveEnemy);
                Score();
            }
        }
	}

    void Score()
    {
        //add score 
        playerScore += 50;
       Destroy(GetComponent<BoxCollider>());
        
    }
}

