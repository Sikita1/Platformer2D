using System;
using UnityEngine;

public class AttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private int _delay;

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
        target.ComeUnderAttack(_damage);
    }
}
