using UnityEngine;
using System.Collections;
//using System;
using System.IO;

public class testInputFile : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		//I had to include FULL PATH in order to make it work nicely!!!
		StreamReader myReader = new StreamReader (@"/Users/Darkside/Documents/Skool/CSCI_430/unitySampleInput.txt");
		string myString = myReader.ReadToEnd ();

		Debug.Log ("Input file produced:");
		Debug.Log (myString);
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

}
