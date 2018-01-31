using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallControl : MonoBehaviour 
{
	public Text messageText1, messageText2, DebugText;
	public GameObject Player1, Player2;
	public Rigidbody2D rb2d;
	public float maxSpeed;
	public static int winScore = 10;
	public Transform pauseMenu;

	private Vector2 vel;

	IEnumerator Delay (float time)
	{
		yield return new WaitForSeconds (time);
	}

	//Function that sets the balls initial velocity and direction
	public void GoBall ()
	{
		StartCoroutine (Delay (3));

		int rand = Random.Range (0, 2);
		float force = Random.Range (-100, 100);

		if (rand == 1) 
		{
			rb2d.AddForce (new Vector2 (200, force));
		} 
		else 
		{
			rb2d.AddForce (new Vector2 (-200, force));
		}

		messageText1.text = "";
		messageText2.text = "";
	}

	//Stops the balls motion and transforms its position to the centre
	public void ResetBall()
	{
		vel = Vector2.zero;
		rb2d.velocity = vel;
		transform.position = Vector2.zero;

		//If the game isn't over the GoBall function is executed
		if (GameManager.Player1Score < winScore && GameManager.Player2Score < winScore) 
		{
			Invoke ("GoBall", 2.0f);
		}
	}

	//Runs ResetBall and then GoBall
	public void RestartGame()
	{
		ResetBall ();
		GameManager.Player1Score = 0;
		GameManager.Player2Score = 0;
		pauseMenu.gameObject.SetActive (false);
		Time.timeScale = 1.0f;
		Time.fixedDeltaTime = 0.02f * Time.timeScale;
		Invoke ("GoBall", 5.0f);

	}

	//Collision detection
	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.collider.CompareTag ("Player")) 
		{
			vel.x = rb2d.velocity.x;
			vel.y = (rb2d.velocity.y / 1.0f) + (coll.collider.attachedRigidbody.velocity.y / 1.0f);
			rb2d.velocity = vel;
		}
	}

	void Start () 
		{
			rb2d = GetComponent<Rigidbody2D> ();
			Invoke("GoBall", 2.0f);
		}

	void FixedUpdate ()
	{
		rb2d.velocity = Vector2.ClampMagnitude (rb2d.velocity, maxSpeed);
	}
}
