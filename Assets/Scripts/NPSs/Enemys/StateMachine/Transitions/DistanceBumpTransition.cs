using UnityEngine;
using UnityEngine.Events;

public class DistanceBumpTransition : Transition
{
    [SerializeField] private float _transitionRange;
    [SerializeField] private float _rangetSpread;

    public event UnityAction AttackOff;

    public float TransitionRange => _transitionRange;

    private void Start()
    {
        _transitionRange += Random.Range(-_rangetSpread, _rangetSpread);
    }

    private void Update()
    {
        if (Target != null && Target?.IsVampirismActiv == false)
            if (Vector2.Distance(transform.position,
                                 Target.transform.position) < _transitionRange)
                NeedTransit = true;
            else
                AttackOff?.Invoke();
    }
}
