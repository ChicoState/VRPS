using UnityEngine;
using System.Collections;

public class quitScript : MonoBehaviour {
	void Update()
	{
		if (Application.platform == RuntimePlatform.Android) 
		{
			if (Input.GetKey (KeyCode.Escape)) 
			{
				Application.Quit();
			}
		}
	}
}
