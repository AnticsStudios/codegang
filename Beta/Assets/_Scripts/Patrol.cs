using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {
    //set some public variables for speed & distance 
	public float speed = 1;
	public float distance = 10;
    //set bool for character moving right 
	public bool movingRight = true;
    //set public assignable object in inspector for the empty game object to detect the ground 
    //is to be place to the right of the player as this script by default moves to the right, and carries the object with a flip
	public Transform groundDetection;
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(Vector2.right * speed * Time.deltaTime);

        // send a ray cast down to detect if there are platforms or not, with this AI it will detect any kind of scalable platform
        // set script on enemy object and place a empty game object about 10-15 to the right in position.x so that way
        // it will send the ray down and detect it before the enemy falls off of the edge 
		RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if(groundInfo.collider == false)
		{
            // if the player is moving right which is set as default 
            if (movingRight == true)
			{
                //flip reverse to move player revers
				transform.eulerAngles = new Vector3(0, -180, 0);
				movingRight = false;
    
			}
			else 
			{
                //else set back to regular positions
				transform.eulerAngles = new Vector3(0, 0, 0);
				movingRight = true;

			}
		}
	}
}
