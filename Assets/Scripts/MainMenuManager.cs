using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsible for the operation of the main menu buttons.
/// </summary>
public class MainMenuManager : MonoBehaviour
{
    public void OnPlayButtonClick()
    {
        SceneSwitcher.StartLevelScene();
    }
    public void OnQuitButtonClick()
    {
        Application.Quit();
    }

}
