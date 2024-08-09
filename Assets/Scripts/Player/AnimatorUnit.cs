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

}
