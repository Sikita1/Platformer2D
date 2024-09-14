using System;
using UnityEngine;

public class AttackState : State
{
    //private const string Attack = "Attack";

    [SerializeField] private int _damage;
    [SerializeField] private int _delay;
    //[SerializeField] private AnimatorUnit _animator;

    public event Action Attack;

    private float _lastAttackTime;

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            Assault(Target);
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void Assault(Player target)
    {
        Attack?.Invoke();
        //_animator.Animator.SetBool(Attack, true);
        target.ComeUnderAttack(_damage);
    }
}
