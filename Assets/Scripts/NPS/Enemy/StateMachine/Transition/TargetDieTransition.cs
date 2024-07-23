using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TargetDieTransition : Transition
{
    private const string Attack = "Attack";

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Target.IsDie == true)
        {
            NeedTransit = true;
            _animator.SetBool(Attack, false);
        }
    }
}
