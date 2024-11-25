using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator
{
    private Transform _object;
    private float _rotationSpeed;

    public Rotator(Transform currentObject, float rotationSpeed)
    {
        _object = currentObject;
        _rotationSpeed = rotationSpeed;
    }

    public void RotateTo(Vector3 direction)
    {
        if (direction.magnitude <= 0)
            return;

        var targetRotation = Quaternion.LookRotation(direction);
        _object.rotation = Quaternion.Slerp(
            _object.rotation, targetRotation, Time.deltaTime * _rotationSpeed);

    }
}
