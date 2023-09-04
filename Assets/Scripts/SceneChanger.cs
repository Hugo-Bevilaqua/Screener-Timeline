using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
	public void ChangeScene(string sceneName)
	{
		//Debug.Log("Changing Scenes");
		SceneManager.LoadScene(sceneName);
	}

	public void ResetScene()
	{
		//Debug.Log("Changing Scenes");
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void Exit()
	{
		Application.Quit();
	}
}