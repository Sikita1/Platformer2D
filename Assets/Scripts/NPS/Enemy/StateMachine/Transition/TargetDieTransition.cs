using UnityEngine.Events;

public class TargetDieTransition : Transition
{
    public event UnityAction StopAttack;

    private void Update()
    {
        if (Target.IsDie && Target?.IsVampirismActiv == false)
        {
            NeedTransit = true;
            StopAttack?.Invoke();
        }
    }
}
