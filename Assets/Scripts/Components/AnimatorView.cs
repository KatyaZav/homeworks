using UnityEngine;

public class AnimatorView
{
    private readonly int IsRunningKey = Animator.StringToHash("run");
    private readonly int IsGetingDamage = Animator.StringToHash("damage");
    private readonly int IsDead = Animator.StringToHash("die");
    private readonly int _enjureLayer = 1;

    private Animator _animator;

    public AnimatorView(Animator animator)
    {
        _animator = animator;
    }

    public void SetLayerWeight(int layerIndex, float weight)
    {
        _animator.SetLayerWeight(layerIndex, weight);
    }

    public void SetEnjureLayerWeight(float weight)
    {
        _animator.SetLayerWeight(_enjureLayer, weight);
    }

    public void SetRunning(bool isRunning)
    {
        _animator.SetBool(IsRunningKey, isRunning);
    }

    public void GetDamage()
    {
        _animator.SetTrigger(IsGetingDamage);
    }

    public void Dead()
    {
        _animator.SetTrigger(IsDead);
    }
}
