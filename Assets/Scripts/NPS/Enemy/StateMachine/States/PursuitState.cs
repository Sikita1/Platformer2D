using UnityEngine;

public class PursuitState : State
{
    [SerializeField] private float _speed;
    [SerializeField] private PatrollingState _movement;

    [SerializeField] private AnimatorUnit _animator;

    private void Update()
    {
        if (Target != null)
        {
            Vector3 direction = Target.transform.position - transform.position;

            transform.position = Vector2.MoveTowards(transform.position,
                                                     Target.transform.position,
                                                     _speed * Time.deltaTime);

            _movement.Turn(direction);
        }
    }

    private void OnDisable()
    {
        _animator.Animator.StopPlayback();
    }
}
