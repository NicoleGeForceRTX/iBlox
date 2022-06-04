using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains information about block activity/inactivity in game language,
/// inherited from Block class
/// </summary>
public class ToggleableBlock : Block
{
    [Serializable] public struct Info
    {
        public GenericInfo  genericInfo;
        public bool initialActive;
    }

    [SerializeField] private Material activeMaterial;
    [SerializeField] private Material inactiveMaterial;
    private Collider _collider;
    private Renderer _renderer;
    private bool _isActive = false;

    public void Awake()
    {
        name = "Toggleable Block";
        _renderer = GetComponent<Renderer>();
        _collider = GetComponent<Collider>();
    }

    public void SetInfo(Info info)
    {
        base.SetInfo(info.genericInfo);
        var color = info.genericInfo.color;
        activeMaterial.color = color;
        color.a = 0.5f;
        inactiveMaterial.color = color;
        _isActive = info.initialActive;
        ActiveChanged();
        transform.localScale += new Vector3(0, 0.05f, 0);
    }

    public void ConnectToButton(ToggleButton button)
    {
        button.OnIsActiveChange.AddListener(() =>
        {
            _isActive = !_isActive;
            ActiveChanged();
        });
    }

    private void ActiveChanged()
    {
        _collider.isTrigger = !_isActive;
        _renderer.material = _isActive ? activeMaterial : inactiveMaterial;
    }
}
