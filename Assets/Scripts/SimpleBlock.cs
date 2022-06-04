using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Is responsible for individual information about the simple block,
/// inherited from Block class.
/// </summary>
[RequireComponent(typeof(Renderer))]
public class SimpleBlock : Block
{
    [Serializable]
    public struct Info
    {
        public Block.GenericInfo genericInfo;
        //if "true" then block will not move horizontally.
        public bool freezeHorizontal;
        //if "true" then block will not move vertically.
        public bool freezeVertical;
    }

    private void Awake()
    {
        name = "Simple Block";
    }

    public void SetInfo(Info info)
    {
        base.SetInfo(info.genericInfo);
        var movement = GetComponent<BlockMovement>();
        movement.HorizontalMovable = !info.freezeHorizontal;
        movement.VerticalMovable = !info.freezeVertical;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation |
             RigidbodyConstraints.FreezePositionY |
            (info.freezeHorizontal ? RigidbodyConstraints.FreezePositionZ : RigidbodyConstraints.None) |
            (info.freezeVertical ? RigidbodyConstraints.FreezePositionX : RigidbodyConstraints.None);
    }


}
