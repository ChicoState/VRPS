﻿/*
Reticles:
	Drawing a reticle in unity development kit was a fair challenge. 
    The obvious thinking is to simply create a crosshair that will track your head movement, 
    by doing that then as your head moves left the crosshair will follow, and vice versa. However, 
    when you look at different planes in environment then your eyes will adjust themselves 
    probably to account for that depth, and if your reticle cannot adapt to the depth of 
    field changes then it might be perceived as double image. In order for the 
    reticle to work properly, it must be redrawn directly into the object the user is looking at.
Steps
1.	Create a PNG transparent image http://www190.lunapic.com/editor/
2.	Import the image and select alpha is transparency.
3.	Create a new Material in the Environment 
4.	For the material under shader select unlit/Transparent.
5.	Attach the picture as texture to the material.
*/


using UnityEngine;
using System.Collections;

public class Reticle : MonoBehaviour {
    public Camera CameraFacing;

     // the obejct that controls when the reticle shows up on the screen
    private MeshRenderer MeshRendObj { get { return GetComponent<MeshRenderer>(); } }

    private bool stair_to_select;
    private float defaultPosZ;
    float distance;
    private Vector3 Reticle_Scale;

    // Use this for initialization
    void Start () {
        Reticle_Scale = transform.localScale; // getting the original scale of the reticle at start up, this can be changed from the GUI
        defaultPosZ = transform.localPosition.z;

        MeshRendObj.enabled = false; // at the start of the scene, the reticle is disabled from view. 
    }

    public void Rotate_Off()
    {
        stair_to_select = false;
        MeshRendObj.enabled = false; // When an object is Unhighlighed/Clicked allow the Reticle to disappear.
    }

    public void Rotate_On()
    {
        stair_to_select = true;
        MeshRendObj.enabled = true; // When an object is highlighted allow the Reticle to appear.
    }
    
    // Update is called once per frame
    void Update () {
        // we will identify the closest object the camera is looking at so that we may
        // draw the reticle correctly on the closest object. this will prevent the double image effect.
        RaycastHit hit;
        Ray ray = new Ray(CameraFacing.transform.position,
                            CameraFacing.transform.rotation * Vector3.forward);

        if (Physics.Raycast(ray, out hit))
        {
            distance = hit.distance; // when the ray collides with an object it will set the distance to the objects distance from the camera.

        }//if
        else { distance = defaultPosZ; }// incase the ray doesnt hit a thing


        //Vector3(0.1f, 0.1f, 0.1f) will allow us the scale the crosshair linearly as the distance changes.
        // longer distances = bigger cross hair, closer distances = smaller cross hair.
        transform.localScale = Reticle_Scale * 1.5f;

        if (!stair_to_select)
        {
            transform.LookAt(CameraFacing.transform.position); //this will allow the reticle to face the position 
                                                               //of the camera in the world
            transform.Rotate(0.0f, 180.0f, 0.0f);              // allow the reticle to rotate around the y axis 
                                                               // in order to have it always facing the camera  
        }
        else {

            transform.Rotate(0.0f, 0.0f, 12.0f);                 // if stop_looking = true, then stop making the reticle
                                                                // look at the camera and allow it to rotate about the z-axis.
        }

        // now we will make the reticle follow the camera forward facing vector in order to have the reticle
        // move with respect to your head movement.
        transform.position = CameraFacing.transform.position +
            (CameraFacing.transform.rotation * Vector3.forward * 1.0f);

    }//update
    
}//class

