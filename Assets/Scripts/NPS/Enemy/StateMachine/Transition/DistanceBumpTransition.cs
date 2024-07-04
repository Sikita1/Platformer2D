using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DistanceBumpTransition : Transition
{
    [SerializeField] private float _transitionRange;
    [SerializeField] private float _rangetSpread;

    private Animator _animator;

    public float TransitionRange => _transitionRange;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _transitionRange += Random.Range(-_rangetSpread, _rangetSpread);
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.transform.position) < _transitionRange)
            NeedTransit = true;
        else
            _animator.SetBool("Attack", false);
    }
}
