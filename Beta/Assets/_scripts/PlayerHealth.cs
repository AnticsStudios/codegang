using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
	private int playerHealth = PlayerPrefs.GetInt("playerTotalHealth");
	public bool hasDied;

	void Start () 
	{
		hasDied = false;
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
