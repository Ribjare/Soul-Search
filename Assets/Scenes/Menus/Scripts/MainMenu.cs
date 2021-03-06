﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Start()
    {
        Cursor.visible = true;
    }

    public void PlayGame()
    {
        Cursor.visible = false;
        SceneManager.LoadScene("FirstAnimation");
    }

    public void ShowControls()
    {
        Cursor.visible = false;

        //Show controls menu
        SceneManager.LoadScene("ControlsMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
