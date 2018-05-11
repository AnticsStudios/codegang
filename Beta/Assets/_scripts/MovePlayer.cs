using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {
	public int playerSpeed = 10;
	private bool facingRight = true;
	public int playerJumpPower = 200;
	private float moveX;
	public bool isGrounded;
	
	// Update is called once per frame
	void Update () 
	{
		PlayerMove();
		PlayerRaycast();
	}

    void PlayerMove()
	{
		//Controls
		moveX = Input.GetAxis("Horizontal");
		//Animations

        if (Input.GetButtonDown ("Jump") && isGrounded == true)
		{
			Jump();
		}
       

		//Player direction
		if (moveX > 0.0f && facingRight == false)
		{
			FlipPlayer();
		}

		else if(moveX < 0.0f && facingRight == true)
		{

			FlipPlayer();
		}
		//Physics
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}

    void Jump()
	{
		isGrounded = false;
		GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
	}

	void FlipPlayer()
	{
		facingRight = !facingRight;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		Debug.Log("grounded with" + col.collider.name);
	    if (col.gameObject.tag == "Ground") 	
		{
			isGrounded = true;
		}
	}
    void PlayerRaycast()
	{
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (hit.distance < 0.9f && hit.collider.tag == "Enemy")
		{
			GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000); 

		}
	}
}
