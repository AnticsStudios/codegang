using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {
	public int playerSpeed = 5;
	private bool facingRight = true;
	private int playerJumpPower = 525;
	private float moveX;
    public bool isGrounded;
    public bool secondJump;
    public bool isAboveEnemy;
    public int jumps = 0;
	
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

        if (Input.GetButtonDown ("Jump") /*&& isGrounded == true*/ && secondJump == false)

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
        jumps++;
        //
        isGrounded = false;
       

        if (jumps > 1)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * (playerJumpPower - 50)); 
            secondJump = true;
        }else
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        }
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
	    if (col.gameObject.tag == "Ground") 	
		{
            jumps = 0;
            isGrounded = true;
            secondJump = false;
          
        }
	}
    void PlayerRaycast()
	{
        Debug.DrawLine(transform.position, Vector2.down);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (hit.distance < 0.9f && hit.collider.tag == "Enemy")
		{
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
            isAboveEnemy = true;
        }
        else { isAboveEnemy = false; }
	}
}
