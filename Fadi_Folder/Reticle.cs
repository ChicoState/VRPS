/*
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
    private float defaultPosZ;
    private Vector3 Reticle_Scale;
    public Camera CameraFacing;

	// Use this for initialization
	void Start () {
        Reticle_Scale = transform.localScale; // getting the original scale of the reticle at start up, this can be changed from the GUI
        defaultPosZ = transform.localPosition.z;
    }
	
	// Update is called once per frame
	void Update () {
        float distance;

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
        transform.localScale = Reticle_Scale * distance;

        transform.LookAt(CameraFacing.transform.position); // this will allow the reticle to face the position 
                                                           //of the camera in the world
        transform.Rotate(0.0f, 180.0f, 0.0f);              // allow the reticle to rotate around the y axis 
                                                           // in order to have it always facing the camera

        // now we will make the reticle follow the camera forward facing vector in order to have the reticle
        // move with respect to your head movement.
        transform.position = CameraFacing.transform.position +
            (CameraFacing.transform.rotation * Vector3.forward * distance);

    }//update
}
