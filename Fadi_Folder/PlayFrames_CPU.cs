using UnityEngine;
using System.Collections;

// Written and modified by Fadi Yousif
// Main Concept taking from : http://bernieroehl.com/360stereoinunity/
/*
main problems with MovieTexture
1- requires unity pro (125$ per month)
2- it only targets desktops and not mobile devices.

The alterantive is convert the video file into a series of frames that can
be played as a video. To do this we are going to use ffmpeg
*/

public class PlayFrames_CPU : MonoBehaviour {

    public GameObject LeftSphere, RightSphere;
    public string Folder_Name;
    public string Pictures_Name;
    public string Digit_count = "000";
    public int Number_Of_Frames;
    public float FrameRate;
    public AudioClip sound; // the audio clip

    //With this Material object, a reference to the game object Material can be stored  
    private Material LsphereMaterial, RsphereMaterial;
    private AudioSource Audio { get { return GetComponent<AudioSource>(); } } // returns the audio source on the game object
    private Texture2D[] frames; // an array called frames of type Texture2D
    private bool Play_State = false; // a boolean value to decide when to play/stop the video on the sphere
    private int CurrentFrame, i;
 

    public void Play_On()
    {
        Play_State = true; // will allow the video to play
    }
    public void Play_Off()
    {
        Play_State = false; // will disable the video
    }

    void Awake()
    {
        //Material objects that reference the renderer of both spheres.
        //Doing this step actually saves alot of Computational resources.
        LsphereMaterial = LeftSphere.GetComponent<Renderer>().material;
        RsphereMaterial = RightSphere.GetComponent<Renderer>().material;
        LsphereMaterial.mainTexture = (Texture2D)Resources.Load(Folder_Name + "/" + Pictures_Name + 0.ToString(Digit_count)); // load first frame and applied it as texture
    }

    // Use this for initialization
    void Start () {
        gameObject.AddComponent<AudioSource>(); // add an Audio source to the Gameobejct
        Audio.clip = sound;
        Audio.playOnAwake = false; // make sure it doesnt play on awake

        frames = new Texture2D[Number_Of_Frames]; // intialize the array which holds the frames
        //frames[0].
        CurrentFrame = 0; i = 1;
    }
	
	// Update is called once per frame
	void Update () {
        if (Play_State)
        {
            //This functions will call the PlayLoop function and define the playback speed.
            StartCoroutine("PlayVideo", (1 / FrameRate)); // the delay field controls the framerate.

            LsphereMaterial.mainTexture =
            RsphereMaterial.mainTexture = frames[CurrentFrame];
        }
    }

    //The following methods return a IEnumerator so they can be yielded:  
    //A method to play the animation in a loop  
    IEnumerator PlayVideo(float delay)
    {
        if (!Audio.isPlaying)
            Audio.Play();

        //Wait for the time defined at the delay parameter  
        yield return new WaitForSeconds(delay);

        //Advance one frame  
        CurrentFrame = (++CurrentFrame) % Number_Of_Frames; // allows the frames to loop.

        //This will if-statement will stop running after all the frames have been laoded into the frames array.
        if (i < Number_Of_Frames)
        {
            // loads the first element of the array with the first frame.
            frames[0] = (Texture2D)Resources.Load(string.Format(Folder_Name + "/" + Pictures_Name + 0.ToString(Digit_count)));
            // loads the rest of elements into the array.
            frames[i] = (Texture2D)Resources.Load(Folder_Name + "/" + Pictures_Name + i.ToString(Digit_count), typeof(Texture2D));
            i++;
        }

        //Stop this coroutine  
        StopCoroutine("PlayVideo");
    }
}// class







/*
    if(i < Number_Of_Frames) // this if statement will stop executing once the array has been filled with every frame.
    {
        frames[i] = (Texture2D)Resources.Load(string.Format("ItalyPictures/frame{0:d4}", i+1));
        i++;
    }
    */

//Timecounter += Time.deltaTime;
//            CurrentFrame = (int)(FrameRate* Timecounter);

//            if (CurrentFrame >= Number_Of_Frames)
//            {
//                Audio.Stop();
//                Timecounter = 0;
//                CurrentFrame = frames.Length - 1;        
//            }