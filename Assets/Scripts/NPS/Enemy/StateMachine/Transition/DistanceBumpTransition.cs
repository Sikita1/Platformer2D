using UnityEngine;

public class DistanceBumpTransition : Transition
{
    private const string Attack = "Attack";

    [SerializeField] private float _transitionRange;
    [SerializeField] private float _rangetSpread;

    [SerializeField] private AnimatorUnit _animator;

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
                _animator.Animator.SetBool(Attack, false);
    }
}
