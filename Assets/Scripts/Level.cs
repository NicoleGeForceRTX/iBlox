using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Level configuration.
/// </summary>
[CreateAssetMenu(menuName = "Level")]
public class Level : ScriptableObject
{
    /// <summary>
    /// Block information.
    /// </summary>
    [SerializeField] private List<SimpleBlock.Info> simpleBlocks;
    [SerializeField] private MainBlock.Info mainBlock;
    [SerializeField] private List<ToggleButton.Info> toggleButtons;
    //information about all blocks.
    public List<SimpleBlock.Info> SimpleBlocks { get => simpleBlocks;}
    //information about main block.
    public MainBlock.Info MainBlock { get => mainBlock;}
    public List<ToggleButton.Info> ToggleButtons { get => toggleButtons; }
}

