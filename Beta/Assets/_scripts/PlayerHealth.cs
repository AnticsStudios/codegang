using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
    private int playerHealth;
	public bool hasDied;

	void Start () 
	{
        hasDied = false;
        if (PlayerPrefs.GetInt("playerTotalHealth") != 0)
        {
            playerHealth = PlayerPrefs.GetInt("playerTotalHealth");
        }
        else
        {
            PlayerPrefs.SetInt("playerTotalHealth", 100);
        }

	}

	void Update () 
	{
		if (gameObject.transform.position.y < -10)
		{
			hasDied = true;
		}
		if (hasDied == true)
		{
			StartCoroutine("Die");
		}
	}

    IEnumerator Die ()
	{
		SceneManager.LoadScene("GameScene");
		//yield return new WaitForSeconds(2);
		yield return null;
	}
}
