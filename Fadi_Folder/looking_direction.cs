using UnityEngine;
using System.Collections;

public class looking_direction : MonoBehaviour
{
    public Camera CameraFacing;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(CameraFacing.transform.position, CameraFacing.transform.rotation * Vector3.forward);//forward ray of the camera.

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("look_tag"))
            {
                Debug.Log("looking");
            }
        }//if
        else
        {
            Debug.Log("Not looking");
        }


    }//update
}//class

