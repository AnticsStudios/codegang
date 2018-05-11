using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour 
{
	public int EnemySpeed = 1;
    public int XMoveDirection = 1;
    
   
    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast (transform.position, new Vector2(XMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
        if (hit.distance < 20) //distance between center of character and edge, may require testing for different enemies
        {
            //commands for when the player gets hit by enemy / gets in range of their ray
            Flip();
        }
    }
	void Flip()
    {
        if (XMoveDirection > 0)
        {
            XMoveDirection = -1;
        }
        else
        {
            XMoveDirection = 1;
        }
    }


}
