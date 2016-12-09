using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassroomManager : MonoBehaviour {

    public Transform GVCamera, CameraObejct, NewSpeechMenu, ClassRoomObj;

    public void Goback()
    {
        GVCamera.gameObject.SetActive(false);
        NewSpeechMenu.gameObject.SetActive(true);
        CameraObejct.gameObject.SetActive(true);
        ClassRoomObj.gameObject.SetActive(false);
    }
}
