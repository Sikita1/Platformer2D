using UnityEngine;

public class VisualDistanceTransition : Transition
{
    [SerializeField] private float _distanceAttack = 15f;

    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.transform.position) > _distanceAttack)
            NeedTransit = true;
    }
}
