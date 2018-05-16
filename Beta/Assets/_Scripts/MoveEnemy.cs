﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour 
{
    public int EnemySpeed = 2;
    public int XMoveDirection = 1;
    public float Xoffset = 1.5f;
    public float YOffset = -0.5f;
   
    // Update is called once per frame
    void Update()
    {
        Vector2 OffsetPos = transform.position;
        OffsetPos.x += XMoveDirection * Xoffset;
        OffsetPos.y += YOffset;

        RaycastHit2D hit = Physics2D.Raycast(OffsetPos, new Vector2(transform.position.x + XMoveDirection * EnemySpeed, transform.position.y), 5);
        Debug.DrawLine(OffsetPos, new Vector2((transform.position.x) + XMoveDirection * EnemySpeed, transform.position.y));
        gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
        Debug.DrawLine(OffsetPos, new Vector2(transform.position.x, transform.position.y - 0.5f));
        RaycastHit2D hitBelow = Physics2D.Raycast(OffsetPos, Vector2.down, 5);
        if(/*hit.collider != null ||*/ hitBelow.collider == null )
//        if (hit.distance < 0 || hitBelow.distance > 1) //distance between center of character and edge, may require testing for different enemies
        {
            //commands for when the player gets hit by enemy / gets in range of their ray
            Flip();
            Vector2 localScale = gameObject.transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
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
