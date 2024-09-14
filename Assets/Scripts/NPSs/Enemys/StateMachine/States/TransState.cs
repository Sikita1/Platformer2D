using System;

public class TransState : State
{
    public event Action ComeOut;
    public event Action Entered;

    private void Update()
    {
        if (Target?.IsVampirismActiv == false)
            ComeOut?.Invoke();
        else
            Entered?.Invoke();
    }
}
