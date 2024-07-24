using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    private Func<Player> _targetProvider;

    protected Player Target => _targetProvider.Invoke();

    public void Enter(Func<Player> targetProvider)
    {
        if(enabled == false)
        {
            _targetProvider = targetProvider;
            enabled = true;

            foreach (Transition transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(_targetProvider);
            }
        }
    }

    public void Exit()
    {
        if (enabled)
            foreach (Transition transition in _transitions)
                transition.enabled = false;

        enabled = false;
    }

    public State GetNextState()
    {
        foreach (Transition transition in _transitions)
            if (transition.NeedTransit)
                return transition.TargetState;

        return null;
    }
}
