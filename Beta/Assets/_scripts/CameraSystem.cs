using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour {
    
	private GameObject player;
	private float xMin = 0.2f;
	private float xMax = 2000.0f;
	private float yMin = 2.5f;
	private float yMax = 10.0f;

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
