//used this to print to screen and double check file path working on phone
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class writeStreamingAssetsPathToText : MonoBehaviour
{
	private Text myText;
	// Use this for initialization
	void Start ()
	{
		myText = GetComponent<Text> ();
		//Application.streamingAssetsPath comes up w/
		//this comes out to be "jar:file:///data/app/com.VRPS.myProductName-1/base.apk!/assets"
		myText.text = Application.persistentDataPath;
		//comes up w/ /storage/emulated/0/Android/data/com.VRPS.myProductName/files
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
}
