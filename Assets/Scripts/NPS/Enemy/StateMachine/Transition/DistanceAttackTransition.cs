public class DistanceAttackTransition : Transition
{
    private void Update()
    {
        if (Target?.IsDie == false)
                NeedTransit = true;
    }
}
