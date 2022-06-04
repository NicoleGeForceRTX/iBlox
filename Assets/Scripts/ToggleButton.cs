using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Contains information about the button, 
/// the blocks it activates/deactivates. Has an event that fires on click.
/// </summary>
public class ToggleButton : MonoBehaviour
{
    [Serializable] public struct Info
    {
        public Vector3 position;
        public Color color;
        public List<ToggleableBlock.Info> toggleableBlocks;
    }
    private UnityEvent _onIsActiveChange = new UnityEvent();
    private bool _isActive = false;
    private Renderer _renderer;
    [SerializeField] private Material _activeMaterial;
    [SerializeField] private Material _inactiveMaterial;
    private Color color;

    public UnityEvent OnIsActiveChange { get => _onIsActiveChange;}

    private void Awake()
    {
        name = "Toggle Button";
        _renderer = GetComponent<Renderer>();
        
    }

    public void SetInfo(Info info)
    {
        transform.position = info.position;
        color = info.color;
        color.a = 0.5f;
        _renderer.material = _activeMaterial;
        _renderer.material.color = color;
    }

    private void OnTriggerEnter(Collider other)
    {
        _isActive = !_isActive;
        OnIsActiveChange.Invoke();
        _renderer.material = _isActive ? _inactiveMaterial : _activeMaterial;
        _renderer.material.color = color;

    }


}
