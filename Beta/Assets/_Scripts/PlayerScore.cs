using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{

	public GameObject playerScoreUI;
    public Transform scoreDetection;
	private int playerScore;
    private int speed = 5;
    private float distance = 2;

    private void Start()
    {
        if (PlayerPrefs.GetInt("playerTotalScore") != 0)
        {
            playerScore = PlayerPrefs.GetInt("playerTotalScore");
        }
        else
        {
            PlayerPrefs.SetInt("playerTotalScore", 10);
        }
    }

    void Update()
	{
        
        //print UI to screen
		playerScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + playerScore);
        PlayerPrefs.SetInt("playerTotalScore", playerScore);
        Debug.DrawLine(scoreDetection.position, Vector2.down);
        
        RaycastHit2D scoreInfo = Physics2D.Raycast(scoreDetection.position, Vector2.down, distance);

    }
    //check 2D trigger / collision
	void OnTriggerEnter2D(Collider2D trig)
	{
        //if tag is enemy, call score basic for now 
        if (trig.gameObject.tag == "Enemy")
        {
            Score(50);
            Destroy(trig.gameObject);
        }
	}

    void Score(int amountOfPoints)
    {
		//add score 
		playerScore += amountOfPoints;

    }
}

