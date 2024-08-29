public class DistanceAttackTransition : Transition
{
    private void Update()
    {
        if (Target?.IsDie == false && Target?.IsVampirismActiv == false)
                NeedTransit = true;
    }
}
