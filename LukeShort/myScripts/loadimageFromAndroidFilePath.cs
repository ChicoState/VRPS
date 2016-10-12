//Fixed and very much working method to access com.productName.appName folder on android
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class loadimageFromAndroidFilePath : MonoBehaviour {

	// Use this for initialization
	// Don't want to use a void here, because we need to be able to yield
	//   when we "download" the texture
	IEnumerator Start ()
	{
		string myPath = Application.persistentDataPath;
		string imagePath = "file://" + myPath + "/img1.png";
		WWW myUrl = new WWW (imagePath);
		yield return myUrl;

		Renderer myRend = GetComponent<Renderer> ();
		myRend.material.mainTexture = myUrl.texture;
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
}
