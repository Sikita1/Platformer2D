using UnityEngine;

public class TargetDieTransition : Transition
{
    [SerializeField] private AnimatorUnit _animator;

    private const string Attack = "Attack";

    private void Update()
    {
        if (Target.IsDie)
        {
            NeedTransit = true;
            _animator.Animator.SetBool(Attack, false);
        }
    }
}
