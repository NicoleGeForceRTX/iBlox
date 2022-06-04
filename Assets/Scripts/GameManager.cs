using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controll the game events.
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField] private MainBlock mainBlockPrefab;
    [SerializeField] private SimpleBlock simpleBlockPrefab;
    [SerializeField] private ToggleButton toggleButtonPrefab;
    [SerializeField] private ToggleableBlock toggleableBlockPrefab;
    [SerializeField] private KeyCode verticalKeyUp;
    [SerializeField] private KeyCode verticalKeyDown;
    [SerializeField] private KeyCode horizontalKeyUp;
    [SerializeField] private KeyCode horizontalKeyDown;
    [SerializeField] private TMP_Text numberLevelText;
    [SerializeField] private float speed;
    private Transform _transform;
    private LevelProvider _levelProvider;
    private List<BlockMovement> _blockMovements = new List<BlockMovement>();

    private void Start()
    {
        _levelProvider = LevelProvider.Find();
        if (_levelProvider == null)
        {
            //if LevelProvider wasn't created.
            throw new System.Exception("LevelProvider not found.");
        }
        var level = _levelProvider.CurrentLevel;
        _transform  = transform;
        level.SimpleBlocks.ForEach(CreateSimpleBlock);
        CreateMainBlock(level.MainBlock);
        level.ToggleButtons.ForEach(CreateToggleButton);
        numberLevelText.text = $"{_levelProvider.CurrentNumberLevel + 1} level";

    }

    private void CreateMainBlock(MainBlock.Info info)
    {
        var mainBlock = Instantiate(mainBlockPrefab, _transform);
        mainBlock.SetInfo(info);
        mainBlock.OnFinish.AddListener(() =>
        {
            NextLevel();
        });
        _blockMovements.Add(mainBlock.GetComponent<BlockMovement>());
    }

    private void CreateSimpleBlock(SimpleBlock.Info info)
    {
        var block = Instantiate(simpleBlockPrefab, _transform);
        block.SetInfo(info);
        _blockMovements.Add(block.GetComponent<BlockMovement>());
    }

    private void CreateToggleButton(ToggleButton.Info info)
    {
        var button = Instantiate(toggleButtonPrefab, _transform);
        button.SetInfo(info);
        var buttonTransform = button.transform;
        info.toggleableBlocks.ForEach(blockInfo =>
        {
            var block = Instantiate(toggleableBlockPrefab, _transform);
            block.SetInfo(blockInfo);
            block.ConnectToButton(button);
        });
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(horizontalKeyUp))
        {
            _blockMovements.ForEach((block) => block.HorizontalMove(speed));
        }
        else if(Input.GetKey(horizontalKeyDown))
        {
            _blockMovements.ForEach((block) => block.HorizontalMove(-speed));
        }

        if (Input.GetKey(verticalKeyUp))
        {
            _blockMovements.ForEach((block) => block.VerticalMove(speed));
        }
        else if (Input.GetKey(verticalKeyDown))
        {
            _blockMovements.ForEach((block) => block.VerticalMove(-speed));
        }
    }

    private void Update()
    {
        
        if (Input.GetKey(KeyCode.R))
        {
            Restart();
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            NextLevel();
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            PreviousLevel();
        }

        else if (Input.GetKey(KeyCode.Escape))
        {
            BackToMenu();
        }
       
    }

    /// <summary>
    /// Switches to the next level and restarts the scene.
    /// </summary>
    public void NextLevel()
    {
        _levelProvider.SwitchToNextLevel();
        Restart();
    }

    /// <summary>
    /// Switches to the previous level and restarts the scene.
    /// </summary>
    public void PreviousLevel()
    {
        _levelProvider.SwitchToPreviousLevel();
        Restart();
    }

    /// <summary>
    /// Switches to the main menu and restarts the scene.
    /// </summary>
    public void BackToMenu()
    {
        SceneSwitcher.StartMenuScene();
    }

    /// <summary>
    /// Restarts the level scene.
    /// </summary>
    public void Restart()
    {
        SceneSwitcher.StartLevelScene();
    }
}
