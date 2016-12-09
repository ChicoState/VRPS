using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySceneManager : MonoBehaviour {

    public Transform SettingsMenu, DifficultyMenu;

    public void Goback()
    {
        SettingsMenu.gameObject.SetActive(true);
        DifficultyMenu.gameObject.SetActive(false);
    }
}
