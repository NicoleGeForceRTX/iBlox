using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Creates a LevelProvider if it hasn't been created before.
/// </summary>
public class LevelProviderCreator : MonoBehaviour
{
    [SerializeField] private LevelProvider _levelProviderPrefab;

    void Start()
    {
        var levelProvider = LevelProvider.Find();
        if (levelProvider == null)
        {
            Instantiate(_levelProviderPrefab);
        }
    }

}
