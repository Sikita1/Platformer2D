public class VisualDistanceTransition : Transition
{
    private void Update()
    {
        if (Target == null)
            NeedTransit = true;
    }
}
