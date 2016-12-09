using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalyzeSceneManager : MonoBehaviour {

    public Transform MainMenu, AnalyzeMenu;


    public void Goback()
    {
        MainMenu.gameObject.SetActive(true);
        AnalyzeMenu.gameObject.SetActive(false);
    }
}
