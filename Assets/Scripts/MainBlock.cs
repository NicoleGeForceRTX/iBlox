using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Is responsible for individual information about the main block,
/// inherited from Block class.
/// </summary>
public class MainBlock : Block
{
    [Serializable]
    public struct Info
    {
        public Block.GenericInfo genericInfo;
        //if "true" then block will not move horizontally.
        public bool freezeHorizontal;
    }

    public UnityEvent OnFinish = new UnityEvent();
    

    private void Awake()
    {
        name = "Main Block";
    }

    public void SetInfo(Info info)
    {
        base.SetInfo(info.genericInfo);
        var movement = GetComponent<BlockMovement>();
        movement.HorizontalMovable = false;
        movement.VerticalMovable = true;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | 
            RigidbodyConstraints.FreezePositionY |  
            (info.freezeHorizontal ? RigidbodyConstraints.FreezePositionZ : RigidbodyConstraints.None);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            OnFinish.Invoke();
        }
    }


}
