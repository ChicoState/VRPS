using UnityEngine;
using System.Collections;

//Written and Modified by Fadi Yousif
//attach this script to an object that contains the main camera.
public class TranslateCamera : MonoBehaviour
{
  public Vector3[] Location; // declaring an array of vectors that will hold room locations
  public GameObject Sphere1, Sphere2;

  public void Start()
  {
    Location = new Vector3[2];                            // declaring an array of Vector3
    Location[0] = Sphere1.transform.localPosition; // stores the original location of the first shpere inside an array
    Location[1] = Sphere2.transform.localPosition;
  }

  public void ChangeLocation_Italy()
  {
    transform.Translate(Location[0]); //change the camera location to the specefied sphere
  }

  public void ChangeLocation_ClassRoom()
  {
    transform.Translate(Location[1]);
  }
}
