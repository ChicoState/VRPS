using UnityEngine;
using System.Collections;

public class Fan : MonoBehaviour
{
public float FanSpeed;

public void Turn_Off()
{
    //GameObject FanOff = GameObject.FindGameObjectWithTag("Fan_tag");
    FanSpeed = 0.0f;
}

public void Turn_On()
{
    //GameObject FanOn = GameObject.FindGameObjectWithTag("Fan_tag");
    FanSpeed = 5.0f;
}

void Update(){
    transform.Rotate(0, 0, FanSpeed); // (x,y,z) thus we are updating the z position every sec
    }

}//Fan class

