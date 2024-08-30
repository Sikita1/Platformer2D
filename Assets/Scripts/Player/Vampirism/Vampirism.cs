using System;
using System.Collections;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    private const string VampireAnimActiv = "Vampire";

    [SerializeField] private ZoneVampirism _zone;
    [SerializeField] private Health _vampireHealth;
    [SerializeField] private KeystrokeHandler _handler;
    [SerializeField] private AnimatorUnit _animator;
    [SerializeField] private TimerVampirism _timerView;

    private Health _victim;

    private float _absorptionTime = 6f;
    private float _timeCurrent;
    private int _suctionPower = 5;

    private Coroutine _coroutine;

    private WaitForSeconds _wait;

    public event Action Activ;
    public event Action ActivOff;

    public bool IsWorking { get; private set; }
    public bool CanWorking { get; private set; }

    private void Start()
    {
        _timeCurrent = _absorptionTime;
        CanWorking = true;
    }

    private void OnEnable()
    {
        _handler.Vampirism += OnVampirism;
        _timerView.Recharging += OnRecharding;
    }

    private void OnDisable()
    {
        _handler.Vampirism -= OnVampirism;
        _timerView.Recharging -= OnRecharding;

        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private void OnRecharding() =>
        CanWorking = true;

    private void OnVampirism()
    {
        IsWorking = true;
        Activ?.Invoke();

        if (_coroutine == null)
            _coroutine = StartCoroutine(Absorption());
    }

    private IEnumerator Absorption()
    {
        _wait = new WaitForSeconds(1f);
        
        Enemy enemy = _zone.Enemy;

        float speed = 1 / _absorptionTime;

        if (enemy != null)
            _victim = enemy.GetComponent<Health>();

        if (CanWorking && enemy != null)
        {
            while (_vampireHealth.Current < _vampireHealth.MaxValue
                   && _victim.Current > 0
                   && _timeCurrent > 0
                   && enemy != null
                   && IsWorking)
            {
                CanWorking = false;
                _timerView.StartTimer(IsWorking, 0, speed);
                _vampireHealth.Increase(_suctionPower);
                enemy.TakeDamage(_suctionPower);
                _timeCurrent--;
                _animator.Animator.SetBool(VampireAnimActiv, true);

                yield return _wait;
            }
        }

        ActivOff?.Invoke();
        _animator.Animator.SetBool(VampireAnimActiv, false);
        IsWorking = false;
        _timeCurrent = _absorptionTime;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _timerView.StartTimer(IsWorking == false, 1, speed);

        _coroutine = null;
    }
}
