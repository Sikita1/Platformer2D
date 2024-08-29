using UnityEngine;

public class TransState : State
{
    private const string Victim = "Victim";

    [SerializeField] private AnimatorUnit _animator;

    private void Update()
    {
        if(Target?.IsVampirismActiv == false)
            _animator.Animator.SetBool(Victim, false);
        else
            _animator.Animator.SetBool(Victim, true);
    }
}
