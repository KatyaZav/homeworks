using UnityEngine;

public class PointZone : MonoBehaviour, IInitable
{
    [SerializeField] private InputController _inputController;
    [SerializeField] private GameObject _pointView;
    [SerializeField] private PlayerController _player;

    private void OnDestroy()
    {
        _inputController.LeftMouseClicked -= SetPoint;        
        _player.Stoped -= DisactivatePoint;
    }

    public void Init()
    {
        _inputController.LeftMouseClicked += SetPoint;
        _player.Stoped += DisactivatePoint;

        _pointView.SetActive(false);
    }

    private void SetPoint(Vector3 vector)
    {
        _pointView.SetActive(true);
        transform.position = vector;
    }

    private void DisactivatePoint(bool isStoped)
    {
        if (isStoped)
        {
            _pointView.SetActive(false);
        }
    }
}
