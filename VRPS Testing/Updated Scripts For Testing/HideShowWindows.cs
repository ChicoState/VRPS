using UnityEngine;
using System.Collections;

// Written and modified by Fadi Yousif
// script to show or hide windows from the main room after we transition from and to the desired locations. 
// attach to the windows in the main room
public class HideShowWindows : MonoBehaviour
{
    public GameObject Window; // attach the desired gameobejet (note it must have canvas and box collider in its children)
    public Canvas canv;
    public BoxCollider BoxColi;

    public void Start()
    {
        canv = Window.GetComponent<Canvas>(); // get the Canvas component 
        BoxColi = Window.GetComponentInChildren<BoxCollider>();  // get the BoxCollider component 

        canv.enabled = true;
        BoxColi.enabled = true;
    }

    // Make the window visable.
    public void Show()
    {
        canv.enabled = true;
        BoxColi.enabled = true;
    }

    // Make the window disapear.
    public void Hide()
    {
        canv.enabled = false;
        BoxColi.enabled = false;
    }
    /*
    // Toggle the Object's visibility each second.
    void Update()
    {
        // Find out whether current second is odd or even
        bool oddeven = Mathf.FloorToInt(Time.time) % 2 == 0;
        // Enable renderer accordingly
        canv.enabled = oddeven;
        BoxColi.enabled = oddeven;
    }
    */
}
