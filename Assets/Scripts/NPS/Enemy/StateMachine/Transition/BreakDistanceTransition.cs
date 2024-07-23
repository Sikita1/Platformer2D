using UnityEngine;

public class BreakDistanceTransition : Transition
{
    [SerializeField] private DistanceBumpTransition _distanceBump;

    private void Update()
    {
        if (Target != null)
            if (Vector2.Distance(transform.position,
                                 Target.transform.position) > _distanceBump.TransitionRange)
                NeedTransit = true;
    }
}
