using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TargetDieTransition : Transition
{
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
            _animator.SetBool("Attack", false);
        }
    }
}
