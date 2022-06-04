using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Responsible for switching scenes.
/// </summary>
public static class SceneSwitcher 
{
    private const int LevelSceneIndex = 1;
    private const int MainMenuIndex = 0;
    public static void StartLevelScene()
    {
        SceneManager.LoadScene(LevelSceneIndex);
    }


    public static void StartMenuScene()
    {
        SceneManager.LoadScene(MainMenuIndex);
    }
    
}
