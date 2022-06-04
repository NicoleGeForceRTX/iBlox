using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Is responsible for general information about the block,
/// initialization of the block itself.
/// </summary>
public class Block : MonoBehaviour
{
    [Serializable]
    public struct GenericInfo {
        public Vector2 scale;
        public Vector3 position;
        public Color color;
    };

    public void SetInfo(GenericInfo info)
    {
        var tr = GetComponent<Transform>();
        tr.position = info.position;
        tr.localScale = new Vector3(info.scale.x, 1, info.scale.y);
        GetComponent<Renderer>().material.color = info.color;
    }
}
