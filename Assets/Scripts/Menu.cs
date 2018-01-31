using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour 
{
	public BallControl otherScript;
	public void changemenuscene (string sceneName)
	{
		SceneManager.LoadScene (sceneName);
		Time.timeScale = 1.0f;
		Time.fixedDeltaTime = 0.02f * Time.timeScale;
	}

	public void changemenugamescene (string sceneName)
	{
		SceneManager.LoadScene (sceneName);
		otherScript.RestartGame ();
		Time.timeScale = 1.0f;
		Time.fixedDeltaTime = 0.02f * Time.timeScale;
	}

	public void exitGame ()
	{
		Application.Quit();
	}
}
