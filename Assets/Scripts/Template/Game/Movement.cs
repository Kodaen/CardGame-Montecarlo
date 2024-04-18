using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Vector2Reference _moveDirection;
    [SerializeField] private FloatReference _speedMultiplier;
    [SerializeField] private float _moveSpeed = 8f;
    [SerializeField] private float _smoothTime = 0.1f;

    private Rigidbody2D _rb;
    private Vector2 _velocity;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 targetVelocity = _moveSpeed * _speedMultiplier.Value * _moveDirection.Value;
        _rb.velocity = Vector2.SmoothDamp(_rb.velocity, targetVelocity, ref _velocity, _smoothTime);

        if (_moveDirection.Value.x * transform.localScale.x < 0) transform.MultiplyScaleWith(x: -1);
        //UpdateAnimation
    }
}