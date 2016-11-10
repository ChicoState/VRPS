using UnityEngine;
using System.Collections;


// Article http://www.41post.com/4726/programming/unity-animated-texture-from-image-sequence-part-1

public class ImageSequenceTextureArray : MonoBehaviour
{
    //An array of Objects that stores the results of the Resources.LoadAll() method  
    private Object[] objects;
    //Each returned object is converted to a Texture and stored in this array  
    private Texture[] textures;
    //With this Material object, a reference to the game object Material can be stored  
    private Material goMaterial;
    //An integer to advance frames  
    private int frameCounter = 0;

    void Awake()
    {
        //Get a reference to the Material of the game object this script is attached to  
        //this.goMaterial = this.renderer.material;
        this.goMaterial = this.GetComponent<Renderer>().material; 
    }

    void Start()
    {
        //Load all textures found on the Sequence folder, that is placed inside the resources folder  
        //this.objects = Resources.LoadAll("ClassRoomPics/Classroom ", typeof(Texture));
        this.objects =  Resources.LoadAll("ClassRoomPics", typeof(Texture));
        //Initialize the array of textures with the same size as the objects array  
        this.textures = new Texture[objects.Length];

        //Cast each Object to Texture and store the result inside the Textures array  
        for (int i = 0; i < objects.Length; i++)
        {
            this.textures[i] = (Texture)this.objects[i];
        }
    }

    void Update()
    {
        //Call the 'PlayLoop' method as a coroutine with a 0.04 delay  
        StartCoroutine("PlayLoop", 0.04f);
        //Set the material's texture to the current value of the frameCounter variable  
        goMaterial.mainTexture = textures[frameCounter];

    }

    //The following methods return a IEnumerator so they can be yielded:  
    //A method to play the animation in a loop  
    IEnumerator PlayLoop(float delay)
    {
        //Wait for the time defined at the delay parameter  
        yield return new WaitForSeconds(delay);

        //Advance one frame  
        frameCounter = (++frameCounter) % textures.Length; // allows the frames to loop.

        //Stop this coroutine  
        StopCoroutine("PlayLoop");
    }

}

