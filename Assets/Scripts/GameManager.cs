using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
	public static int Player1Score, Player2Score = 0;
	public Text P1Text, P2Text, messageText1, messageText2, DebugText;
	public UIManager UI;
	public Transform pauseMenu;

	GameObject theBall;

	public void resumeGame()
	{
		pauseMenu.gameObject.SetActive (false);
		Time.timeScale = 1.0f;
		Time.fixedDeltaTime = 0.02f * Time.timeScale;
	}

	void Start () 
	{
		theBall = GameObject.FindGameObjectWithTag ("Ball");

		Player1Score = 0;
		Player2Score = 0;
		P1Text.text = Player1Score.ToString ();
		P2Text.text = Player2Score.ToString ();
		messageText1.text = "";
		messageText2.text = "";
		DebugText.text = "";
	}

	//Function that awards points to the players
	public static void Score (string wallID)
	{
		if (wallID == "WallRight") 
		{
			Player1Score++;
		}

		if (wallID == "WallLeft") 
		{
			Player2Score++;
		}
	}

	void FixedUpdate () 
	{
		P1Text.text = Player1Score.ToString ();
		P2Text.text = Player2Score.ToString ();

		if (Player1Score == BallControl.winScore) 
		{
			messageText1.text = " Player 1 Victory! " + "(" + P1Text.text + " - " + P2Text.text + ")";
			theBall.SendMessage ("RestartGame", 2.0f, SendMessageOptions.RequireReceiver);
		}

		if (Player2Score == BallControl.winScore) 
		{
			messageText2.text = " Player 2 Victory! " + "(" + P2Text.text + " - " + P1Text.text + ")";
			theBall.SendMessage ("RestartGame", 2.0f, SendMessageOptions.RequireReceiver);
		}
	}
}
