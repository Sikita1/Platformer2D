using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PursuitState : State
{
    [SerializeField] private float _speed;
    [SerializeField] private PatrollingState _movement;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

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
        _animator.StopPlayback();
    }
}
