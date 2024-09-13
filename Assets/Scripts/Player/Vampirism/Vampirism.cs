using System;
using System.Collections;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private ZoneVampirism _zone;
    [SerializeField] private Health _vampireHealth;
    [SerializeField] private KeystrokeHandler _handler;
    [SerializeField] private TimerVampirism _timerView;

    private Health _victimHealth;

    private float _absorptionTime = 6f;
    private float _timeCurrent;
    private int _suctionPower = 5;

    private Coroutine _coroutine;

    private WaitForSeconds _wait;

    public event Action Activ;
    public event Action ActivOff;

    public bool IsWorking { get; private set; }

    private void Start()
    {
        _timeCurrent = _absorptionTime;
    }

    private void OnEnable()
    {
        _handler.Vampirism += OnVampirism;
    }

    private void OnDisable()
    {
        _handler.Vampirism -= OnVampirism;

        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private void OnVampirism()
    {
        Enemy enemy = null;

        if (_zone.EnemiesDiscovered != null)
            for (int i = 0; i < _zone.EnemiesDiscovered.Count; i++)
                enemy = _zone.EnemiesDiscovered[i];

        if (CanWork(enemy))
        {
            IsWorking = true;
            _coroutine = StartCoroutine(Absorption(enemy));
            Activ?.Invoke();
        }
    }

    private IEnumerator Absorption(Enemy enemy)
    {
        _wait = new WaitForSeconds(1f);

        float speed = 1 / _absorptionTime;

        _victimHealth = enemy.GetComponent<Health>();

        while (_vampireHealth.Current < _vampireHealth.MaxValue
                && _victimHealth.Current > 0
                && _timeCurrent > 0
                && IsWorking)
        {
            _timerView.StartTimer(IsWorking, 0, speed);

            if (_victimHealth.Current < _suctionPower)
            {
                _suctionPower--;
            }
            else
            {
                _vampireHealth.Increase(_suctionPower);
                enemy.TakeDamage(_suctionPower);
            }

            _timeCurrent--;

            yield return _wait;
        }

        ActivOff?.Invoke();
        IsWorking = false;
        _timeCurrent = _absorptionTime;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _timerView.StartTimer(IsWorking == false, 1, speed);
        _coroutine = null;
    }

    private bool CanWork(Enemy enemy) =>
        (enemy != null
         && _coroutine == null
         && _timerView.TimerFull);
}
