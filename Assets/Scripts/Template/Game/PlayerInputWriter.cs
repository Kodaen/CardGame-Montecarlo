using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public class PlayerInputWriter : MonoBehaviour
{
    [SerializeField] private Vector2Variable _moveDirection;
    [SerializeField] private VoidEventChannel _actionKeyEvent;

    private void Awake()
    {
        _moveDirection.Value = Vector2.zero;
    }

    /*
    // Has to match the name of the Inputs Actions

    public void OnMove(InputValue value)
    {
        _moveDirection.Value = value.Get<Vector2>();
    }

    public void OnAction()
    {
        _actionKeyEvent.RaiseEvent();
    }
    */
}
