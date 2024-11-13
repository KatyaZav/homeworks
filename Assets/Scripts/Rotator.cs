using UnityEngine;

public class Rotator
{
    private float _rotationSpeed;
    private Transform _objectTransform;

    public Rotator(float rotateSpeed, Transform objectTransform)
    {
        _rotationSpeed = rotateSpeed;
        _objectTransform = objectTransform;
    }

    public void RotateTo(Vector3 direction)
    {
        if (direction.magnitude <= 0)
            return;

        var targetRotation = Quaternion.LookRotation(direction);
        _objectTransform.rotation = Quaternion.Slerp(
            _objectTransform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
    }
}
