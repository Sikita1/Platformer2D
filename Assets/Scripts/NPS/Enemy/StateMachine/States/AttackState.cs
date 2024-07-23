using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackState : State
{
    private const string Attack = "Attack";

    [SerializeField] private int _damage;
    [SerializeField] private int _delay;

    private float _lastAttackTime;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

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
        _animator.SetBool(Attack, true);
        target.ComeUnderAttack(_damage);
    }
}
