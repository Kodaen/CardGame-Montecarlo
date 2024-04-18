using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] private Vector2Variable _playerMoveDirection;

    private void Awake()
    {
        _playerMoveDirection.Value = Vector2.zero;
    }

    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        _playerMoveDirection.Value = new Vector2(moveX, moveY).normalized;
    }
}
