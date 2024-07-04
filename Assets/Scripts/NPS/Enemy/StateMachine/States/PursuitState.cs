using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PursuitState : State
{
    [SerializeField] private float _speed;
    [SerializeField] private PatrollingState _waypoint;
    
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 direction = Target.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);

        if (!_waypoint.IsFacingRight && direction.x > 0)
            _waypoint.Flip();
        else if (_waypoint.IsFacingRight && direction.x < 0)
            _waypoint.Flip();
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }
}
