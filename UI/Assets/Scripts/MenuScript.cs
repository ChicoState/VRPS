using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour
{
	public void ChangeScene(string sceneName)
	{	
		SceneManager.LoadScene (sceneName);
	}
}