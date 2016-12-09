using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSceneManager : MonoBehaviour {

    public Transform SettingsMenu, TimerMenu;

    public Transform HoursField, MinutesField, SecondsField, TimeLimitMSG;

    bool active = false;

    public void ActivateInputFields()
    {
        active = !active;
        HoursField.gameObject.SetActive(active);
        MinutesField.gameObject.SetActive(active);
        SecondsField.gameObject.SetActive(active);
        TimeLimitMSG.gameObject.SetActive(active);
    }

    public void Goback()
    {
        SettingsMenu.gameObject.SetActive(true);
        TimerMenu.gameObject.SetActive(false);
    }
}
