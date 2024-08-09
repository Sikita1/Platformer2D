using UnityEngine;

public class AttackState : State
{
    private const string Attack = "Attack";

    [SerializeField] private int _damage;
    [SerializeField] private int _delay;

    private float _lastAttackTime;
    [SerializeField] private AnimatorUnit _animator;

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
        _animator.Animator.SetBool(Attack, true);
        target.ComeUnderAttack(_damage);
    }
}
