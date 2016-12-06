using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class goBackSettingsScript : MonoBehaviour {
	void Update()
	{
		if (Application.platform == RuntimePlatform.Android) 
		{
			if (Input.GetKey (KeyCode.Escape)) 
			{
				SceneManager.LoadScene ("settings");
			}
		}
	}
}
