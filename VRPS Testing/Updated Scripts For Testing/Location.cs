using UnityEngine;
using System.Collections;

public class location : MonoBehaviour
{

  // Use this for initialization
  public void Start()
  {
    int number = Random.Range(0, 3);
    if(number != 0)
      transform.Translate(-number, 0, 0);
  }

  // Update is called once per frame
  void Update()
  {

  }
}
