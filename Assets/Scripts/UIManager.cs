using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{
	public Transform pauseMenu;
	public Text DebugText;

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (pauseMenu.gameObject.activeInHierarchy == false) 
			{
				pauseMenu.gameObject.SetActive (true);
				Time.timeScale = 0.0f;
			} 
			else 
			{
				pauseMenu.gameObject.SetActive (false);
				Time.timeScale = 1.0f;
				Time.fixedDeltaTime = 0.02f * Time.timeScale;
			}
		}
	}
}
