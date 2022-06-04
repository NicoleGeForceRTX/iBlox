using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides levels.
/// </summary>
public class LevelProvider : MonoBehaviour
{
    [SerializeField] private List<Level> levels;
    private int _currentNumberLevel = 0;



    public Level CurrentLevel
    {
        get => levels[CurrentNumberLevel];
    }

    public Level NextLevel
    {
        get
        {
            SwitchToNextLevel();
            return CurrentLevel;
        }
    }

    public int CurrentNumberLevel { get => _currentNumberLevel;}

    public static LevelProvider Find()
    {
        var provider = GameObject.Find("LevelProvider");
        return provider == null? null: provider.GetComponent<LevelProvider>();
    }

    public void SwitchToNextLevel()
    {
        _currentNumberLevel++;
        if (CurrentNumberLevel >= levels.Count)
        {
            _currentNumberLevel = 0;
        }
    }

    public void SwitchToPreviousLevel()
    {
        _currentNumberLevel--;
        if (CurrentNumberLevel < 0)
        {
            _currentNumberLevel = levels.Count - 1;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
        name = "LevelProvider";
    }


}
