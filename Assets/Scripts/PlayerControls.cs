﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour 
{
	public KeyCode moveUp = KeyCode.W;
	public KeyCode moveDown = KeyCode.S;
	public float speed;
	public float boundY;

	private Rigidbody2D rb2d;

	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		// Changes velocity based on key input
		var vel = rb2d.velocity;

		if (Input.GetKey (moveUp)) 
		{
			vel.y = speed;
		}

		if (Input.GetKey (moveDown)) 
		{
			vel.y = -speed;
		} 

		else if (!Input.anyKey) 
		{
			vel.y = 0;
		}

		rb2d.velocity = vel;

		// restricts the play area
		var pos = transform.position;

		if (pos.y > boundY) 
		{
			pos.y = boundY;
		} 

		else if (pos.y < -boundY)
		{
			pos.y = -boundY;
		}

		transform.position = pos;
	}
}