using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorUnit : MonoBehaviour
{
    private Animator _animator;

    public Animator Animator => _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    protected void ActiveBoolAnimation(string animationName, bool value) =>
        Animator.SetBool(animationName, value);
}
