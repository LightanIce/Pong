using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotControl : MonoBehaviour 
{
	public float speed;
	public float boundY;
	public float offset;
	public GameObject Ball;
	public Text debugText;

	private Rigidbody2D rb2d;
	private Rigidbody2D ballRb2d;

	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
		ballRb2d = Ball.GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate ()
	{
		var vel = rb2d.velocity;
		var pos = transform.position;
		var ballPosition = Ball.transform.position;
		var ballVel = ballRb2d.velocity;

		// stops movement if ball is close enough to paddle
		if (ballPosition.y <= pos.y+offset || ballPosition.y >= pos.y-offset)
		{
			vel.y = 0;
		}

		// moves paddle up or down if paddle is too far from ball and ball is on its side
		if (ballPosition.y > pos.y+offset && ballPosition.x > 0)
		{
			vel.y = speed;
		}
		if (ballPosition.y < pos.y-offset && ballPosition.x > 0)
		{
			vel.y = -speed;
		}

		// moves paddle to centre if ball is moving away from it
		if (ballVel.x < 0 && pos.y + 0.1 < 0) 
		{
			vel.y = speed;
		}
		if (ballVel.x < 0 && pos.y - 0.1 > 0)
		{
			vel.y = -speed;
		} 
		else if (ballVel.x < 0 && pos.y + 0.1 > 0 && pos.y - 0.1 < 0) 
		{
			vel.y = 0;
		}
			
		rb2d.velocity = vel;

		// restricts the play area
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
