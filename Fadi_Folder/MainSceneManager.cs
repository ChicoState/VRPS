using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneManager : MonoBehaviour {
    public Transform MainMenu, SettingsMenu, NewSpeechMenu, AnalyzeMenu;

    public void Main_Settings()
    {
        SettingsMenu.gameObject.SetActive(true); // activates the Options menu
        MainMenu.gameObject.SetActive(false);
    }

    public void Main_NewSpeech()
    {
        NewSpeechMenu.gameObject.SetActive(true);
        MainMenu.gameObject.SetActive(false);
    }

    public void Main_Analyze()
    {
        AnalyzeMenu.gameObject.SetActive(true);
        MainMenu.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }
    }
}//class
