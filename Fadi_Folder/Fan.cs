using UnityEngine;
using System.Collections;

public class Fan : MonoBehaviour
{
    public float FanSpeed = 3.0f;     // delaring a public variable for the speed of rotation

void Start(){
        transform.Rotate(0, 0, 0);
    }//Start
//------------------------------------------------------------------- 
//This update function gets called once every frame.
void Update(){
        transform.Rotate(0, 0, FanSpeed); // (x,y,z) thus we are updating the z position every sec
    }//Update


}//Fan class
