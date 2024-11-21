using UnityEngine;

public class RandomMoving : IState
{
    private NavigationMover _navigationMover;
    private float _patrolRaduis;
    private float _timeToChangeLocation;

    private Vector3 _settedPoint;
    private float _currentTime;
    private Transform _objPos;

    public RandomMoving(NavigationMover mover, float patrolRaduis, float timeToChangeLocation, Transform obj)
    {
        _navigationMover = mover;
        _patrolRaduis = patrolRaduis;
        _timeToChangeLocation = timeToChangeLocation;
        _objPos = obj;
    }

    public void Enter()
    {
        _currentTime = _timeToChangeLocation;
    }

    public void Exit()
    {
    }

    public void SetPoint(Vector3 point)
    {
    }

    public void Update()
    {
        _currentTime += Time.deltaTime;

        _navigationMover.SetIsMoving(_navigationMover.HasPath);

        if (_currentTime > _timeToChangeLocation)
        {
            _currentTime = 0;
            StartMoveTo(_objPos.transform.position + GetRandomVectorInRaduis(_patrolRaduis));
        }
    }

    private void StartMoveTo(Vector3 vector)
    {
        _navigationMover.SetIsMoving(true);
        _navigationMover.SetPoint(vector);
    }

    private Vector3 GetRandomVectorInRaduis(float raduis)
    {
        float x = Random.Range(-raduis, raduis);
        float z = Random.Range(-raduis, raduis);

        return new Vector3(x, 0, z);
    }
}
