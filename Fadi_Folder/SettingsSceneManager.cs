using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsSceneManager : MonoBehaviour {
    public Transform MainMenu, SettingsMenu, DifficultyMenu, TimerMenu;

    //public void settings_UploadPPT()
    //{
    //    SettingsMenu.gameObject.SetActive(true); // activates the Options menu
    //    MainMenu.gameObject.SetActive(false);
    //}

    public void settings_Timer()
    {
        TimerMenu.gameObject.SetActive(true);
        SettingsMenu.gameObject.SetActive(false);
    }

    public void settings_Difficulty()
    {
        DifficultyMenu.gameObject.SetActive(true);
        SettingsMenu.gameObject.SetActive(false);
    }

    public void Goback()
    {
        MainMenu.gameObject.SetActive(true);
        SettingsMenu.gameObject.SetActive(false);
    }
}//class
