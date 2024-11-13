using UnityEngine;

public class DestroyAction : IAction
{
    private GameObject _thisObject;
    private ParticleSystem _particles;

    public DestroyAction(GameObject thisObject, ParticleSystem particles)
    {
        _thisObject = thisObject;
        _particles = particles;
    }

    public void Activate()
    {
        GameObject.Instantiate(_particles, _thisObject.transform.position, _thisObject.transform.rotation);
        GameObject.Destroy(_thisObject);
    }

    public void Deactivate()
    {
    }

    public void Progressing()
    {
    }
}
