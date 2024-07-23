using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;
    [SerializeField] private Enemy _enemy;

    private Player _target;
    private State _currentState;

    private void OnEnable()
    {
        _enemy.FindTarget += OnFindTarget;
    }

    private void OnDisable()
    {
        _enemy.FindTarget -= OnFindTarget;
    }

    private void OnFindTarget(Player target)
    {
        _target = target;

        GoIntoState();
    }

    private void Start()
    {
        Reset(_firstState);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        State nextState = _currentState.GetNextState();

        if (nextState != null)
            Transit(nextState);
    }

    private void Reset(State startState)
    {
        _currentState = startState;

        GoIntoState();
    }

    private void Transit(State nextState)
    {
        _currentState?.Exit();

        _currentState = nextState;

        GoIntoState();
    }

    private void GoIntoState()
    {
        _currentState?.Enter(() => _target);
    }
}
