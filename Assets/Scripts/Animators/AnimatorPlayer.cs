using UnityEngine;

public class AnimatorPlayer : AnimatorUnit
{
    private const string Run = "Run";
    private const string Bounce = "Jump";
    private const string Attack = "Attack";
    private const string VampireAnimActiv = "Vampire";
    private const string TakeDamage = "TakeDamage";
    private const string Perish = "Die";

    [SerializeField] private Vampirism _vampirism;
    [SerializeField] private KeystrokeHandler _handler;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _vampirism.Activated += OnActivated;
        _vampirism.Deactivated += OnDeactivated;
        _handler.StartedJump += OnStartedJump;
        _handler.FinishedJump += OnFinishedJump;
        _handler.Attack += OnAttack;
        _handler.StartRunning += OnStartRunning;
        _handler.Stay += OnStay;
        _player.TakingDamage += OnTakeDamage;
        _player.Died += OnDie;
    }

    private void OnDisable()
    {
        _vampirism.Activated -= OnActivated;
        _vampirism.Deactivated -= OnDeactivated;
        _handler.StartedJump -= OnStartedJump;
        _handler.FinishedJump -= OnFinishedJump;
        _handler.Attack -= OnAttack;
        _handler.StartRunning -= OnStartRunning;
        _handler.Stay -= OnStay;
        _player.TakingDamage -= OnTakeDamage;
        _player.Died -= OnDie;
    }

    private void OnActivated() =>
        ActiveBoolAnimation(VampireAnimActiv, true);

    private void OnDeactivated() =>
        ActiveBoolAnimation(VampireAnimActiv, false);

    private void OnStartedJump() =>
        ActiveBoolAnimation(Bounce, true);

    private void OnFinishedJump() =>
        ActiveBoolAnimation(Bounce, false);

    private void OnAttack() =>
        ActiveTriggerAnimation(Attack);

    private void OnStartRunning() =>
        ActiveBoolAnimation(Run, true);

    private void OnStay() =>
        ActiveBoolAnimation(Run, false);

    private void OnTakeDamage() =>
        ActiveTriggerAnimation(TakeDamage);

    private void OnDie() =>
        ActiveTriggerAnimation(Perish);
}
