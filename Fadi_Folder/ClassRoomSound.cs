using UnityEngine;
using System.Collections;
using UnityEngine.UI; // for Button class
//using UnityEngine.EventSystems; // for Event Trigger
/*
    The EventTrigger can be used to specify functions you wish to be called 
    for each EventSystem event. You can assign multiple functions to a single 
    event and whenever the EventTrigger receives that event it will call those 
    functions in the order they were provided.
*/

//source https://www.youtube.com/watch?v=FxedJgTsFyQ&index=12&list=PLIxiNSc2uwkrZ73rAEdf2aurKa2ncaDK7
//attached the the button object in unity

//[RequireComponent(typeof(Button))] // this will make sure there is button attached, ift here isnt one then it will create one

public class ClassRoomSound : MonoBehaviour
{

    public AudioClip sound; // the audio clip

    //private Button button { get { return GetComponent<Button>(); } } // returns the button object on the game object
    private AudioSource source { get { return GetComponent<AudioSource>(); } } // returns the audio source on the game object

    // Use this for initialization
    void Start()
    {
        gameObject.AddComponent<AudioSource>(); // add an Audio source to the Gameobejct
        source.clip = sound;
        source.playOnAwake = false; // make sure it doesnt play on awake
    }

    void Update()
    {
        //play audio
        if (!source.isPlaying)
            source.Play();
    }
}


