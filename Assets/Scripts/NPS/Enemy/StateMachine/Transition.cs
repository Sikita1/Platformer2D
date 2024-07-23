using System;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    private Func<Player> _targetProvider;

    protected Player Target => _targetProvider.Invoke();

    public State TargetState => _targetState;
    public bool NeedTransit { get; protected set; }

    public void Init(Func<Player> targetProvider)
    {
        _targetProvider = targetProvider;
    }

    public void OnEnable()
    {
        NeedTransit = false;
    }
}
