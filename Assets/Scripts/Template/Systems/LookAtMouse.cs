using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    [SerializeField] private Transform _center;
    [SerializeField] private float _maxDistance = 1;

    private void Update()
    {
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - _center.position;
        direction = Vector3.ClampMagnitude(direction, _maxDistance);

        transform.position = _center.position + direction;
    }
}
