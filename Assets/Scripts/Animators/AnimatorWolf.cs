using UnityEngine;

public class AnimatorWolf : AnimatorUnit
{
    private const string Attack = "Attack";
    private const string Victim = "Victim";

    [SerializeField] private AttackState _attack;
    [SerializeField] private TransState _trans;
    [SerializeField] private PursuitState _pursuit;
    [SerializeField] private DistanceBumpTransition _distanceBump;
    [SerializeField] private TargetDieTransition _targetDie;

    private void OnEnable()
    {
        _attack.Attack += OnAttack;
        _trans.Entered += OnEntered;
        _trans.ComeOut += OnComeOut;
        _pursuit.StopAnimation += OnStopAnimation;
        _distanceBump.AttackOff += OnAttackOff;
        _targetDie.StopAttack += OnAttackOff;
    }

    private void OnDisable()
    {
        _attack.Attack -= OnAttack;
        _trans.Entered -= OnEntered;
        _trans.ComeOut -= OnComeOut;
        _pursuit.StopAnimation -= OnStopAnimation;
        _distanceBump.AttackOff -= OnAttackOff;
        _targetDie.StopAttack -= OnAttackOff;
    }

    private void OnAttack() =>
        ActiveBoolAnimation(Attack, true);

    private void OnAttackOff() =>
        ActiveBoolAnimation(Attack, false);

    private void OnEntered() =>
        ActiveBoolAnimation(Victim, true);

    private void OnComeOut() =>
        ActiveBoolAnimation(Victim, false);

    private void OnStopAnimation() =>
        Animator.StopPlayback();
}
