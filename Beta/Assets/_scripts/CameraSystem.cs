using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour {
    
	private GameObject player;
	private float xMin = 0.2f;
	private float xMax = 20f;
	private float yMin = 0.8f;
	private float yMax = 1.2f;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	

	void LateUpdate () {
		float x = Mathf.Clamp (player.transform.position.x, xMin, xMax);
		float y = Mathf.Clamp (player.transform.position.y, yMin, yMax);
		gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
	}
}
