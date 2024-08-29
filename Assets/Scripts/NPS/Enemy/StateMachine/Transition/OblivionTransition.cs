public class OblivionTransition : Transition
{
    private void Update()
    {
        if (Target != null)
            if (Target.IsVampirismActiv)
                NeedTransit = true;
    }
}
