//This guy is used to play movie texture and put it on repeat (super hard work here)
using UnityEngine;
using System.Collections;
[RequireComponent (typeof(AudioSource))]//require audio??? 

public class myVideoScript : MonoBehaviour
{
	public MovieTexture myMovie;
	public Renderer myRend;

	// Use this for initialization
	void Start ()
	{
		myRend = GetComponent<Renderer> ();
		myRend.material.mainTexture = myMovie as MovieTexture;//need to cast it as a "MovieTexture"
		myMovie.Play();
		myMovie.loop = true;
	}
}
