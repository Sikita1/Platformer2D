using UnityEngine;

public class DistanceAttackTransition : Transition
{
    [SerializeField] private float _transitionRange;

    public float TransitionRange => _transitionRange;

    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.transform.position) <= _transitionRange && Target.IsDie == false)
            NeedTransit = true;
    }
}
