using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewSpeech : MonoBehaviour {

    public Transform GVCamera, CameraObejct, MainMenu, EnvironmentMenu, ClassroomObejct;//, InterviewObejct;

    ////loads the new scene for the VR environment
    //public void LoadScene(string Name)
    //{
    //    SceneManager.LoadSceneAsync(Name);
    //}

    public void Environment_Classroom()
    {
        GVCamera.gameObject.SetActive(true);
        ClassroomObejct.gameObject.SetActive(true);
        EnvironmentMenu.gameObject.SetActive(false);
        CameraObejct.gameObject.SetActive(false);    
    }

    //public void Environment_Interview()
    //{
    //    GVCamera.gameObject.SetActive(true);
    //    InterviewObejct.gameObject.SetActive(true);
    //    EnvironmentMenu.gameObject.SetActive(false);
    //    CameraObejct.gameObject.SetActive(false);
    //}

    public void Goback()
    {
        MainMenu.gameObject.SetActive(true);
        EnvironmentMenu.gameObject.SetActive(false);
    }
}
