using UnityEngine;

public class DestroyAction : IState
{
    private GameObject _thisObject;
    private ParticleSystem _particles;

    public DestroyAction(GameObject thisObject, ParticleSystem particles)
    {
        _thisObject = thisObject;
        _particles = particles;
    }

    public void Enter()
    {
        GameObject.Instantiate(_particles, _thisObject.transform.position, _thisObject.transform.rotation);
        GameObject.Destroy(_thisObject);
    }

    public void Exit()
    {
    }

    public void Update()
    {
    }
}
