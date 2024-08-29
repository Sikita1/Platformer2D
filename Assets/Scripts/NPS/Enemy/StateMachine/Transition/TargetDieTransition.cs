using UnityEngine;

public class TargetDieTransition : Transition
{
    [SerializeField] private AnimatorUnit _animator;

    private const string Attack = "Attack";

    private void Update()
    {
        if (Target.IsDie && Target?.IsVampirismActiv == false)
        {
            NeedTransit = true;
            _animator.Animator.SetBool(Attack, false);
        }
    }
}
