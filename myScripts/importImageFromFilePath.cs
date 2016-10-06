//C# script to get image file from specified path on device
using UnityEngine;
using System.Collections;

public class importImageFromFilePath : MonoBehaviour {
	//public Renderer myRendererer;
	// Use this for initialization
	void Start ()
	{
		WWW myUrl = new WWW("file:///Users/DarkSide/testfolder/img1.jpg");//the "url" of the image I want

		Renderer myRendererer = GetComponent<Renderer> ();
		myRendererer.material.mainTexture = myUrl.texture;//assign main texture of renderer to this "downloaded" image
	}
	
	// Update is called once per frame
	void Update ()
	{}
}
