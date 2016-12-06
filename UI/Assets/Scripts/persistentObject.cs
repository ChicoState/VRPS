using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class persistentObject : MonoBehaviour
{
	void Update()
	{
		Object.DontDestroyOnLoad (this.gameObject);
		/*PlayerPrefs.SetInt( "previousLevel", SceneManager.GetActiveScene());
		int previousLevel = PlayerPrefs.GetInt( "previousLevel" );*/

		if (Application.platform == RuntimePlatform.Android) 
		{
			if (Input.GetKey (KeyCode.Escape)) 
			{
				//SceneManager.LoadScene (previousLevel);
			}
		}
	}
}