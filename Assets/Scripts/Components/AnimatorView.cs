using System;
using UnityEngine;

public class AnimatorView : MonoBehaviour
{
    private readonly int FullValue = 1, ZeroValue = 0;

    private readonly int IsRunningKey = Animator.StringToHash("run");
    private readonly int IsGetingDamage = Animator.StringToHash("damage");
    private readonly int IsDead = Animator.StringToHash("die");
    private readonly int _enjureLayer = 1;

    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerController _player;

    [SerializeField, Range(0, 1)] private float _layerChangeValue = 0.3f;

    private void Start()
    {
        _player.Damaged += OnDamaged;
        _player.Stoped += ChangeIsGoing;
    }   

    private void OnDestroy()
    {
        _player.Damaged -= OnDamaged;
        _player.Stoped -= ChangeIsGoing;
    }

    #region Animate
    private void SetLayerWeight(int layerIndex, float weight)
    {
        _animator.SetLayerWeight(layerIndex, weight);
    }

    private void SetEnjureLayerWeight(float weight)
    {
        _animator.SetLayerWeight(_enjureLayer, weight);
    }

    private void SetRunning(bool isRunning)
    {
        _animator.SetBool(IsRunningKey, isRunning);
    }

    private void Damage()
    {
        _animator.SetTrigger(IsGetingDamage);
    }

    private void Dead()
    {
        _animator.SetTrigger(IsDead);
    }
    #endregion

    private void OnDamaged(float health)
    {
        if ((health / _player.MaxHealth) < _layerChangeValue)
            SetEnjureLayerWeight(FullValue);
        else
            SetEnjureLayerWeight(ZeroValue);

        if (health == 0)
            Dead();
        else
            Damage();
    }

    private void ChangeIsGoing(bool isStopped)
    {
       SetRunning(isStopped == false);        
    }
}
