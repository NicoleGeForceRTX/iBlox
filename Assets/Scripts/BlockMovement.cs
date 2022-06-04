using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

/// <summary>
/// Is responsible for moving blocks on the plane.
/// </summary>
[RequireComponent(typeof (Rigidbody))]
public class BlockMovement : MonoBehaviour
{

    private Rigidbody _rigidBody;
    private bool _horizontalMovement;
    private bool _verticalMovement;
    public bool VerticalMovable { set => _verticalMovement = value; }
    public bool HorizontalMovable { set => _horizontalMovement = value; }

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

   

    public void HorizontalMove(float value)
    {
        if (_horizontalMovement)
        {
            _rigidBody.velocity += new Vector3(0, 0, value);
        }
    }

    public void VerticalMove(float value)
    {
        if (_verticalMovement)
        {
            _rigidBody.velocity += new Vector3(value, 0, 0);
        }
    }


}
