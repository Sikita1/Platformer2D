using UnityEngine;

public class PatrollingState : State
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    [SerializeField] private Transform _transform;

    private Transform[] _points;
    private int _currentPoint;
    public bool IsFacingRight { get; private set; } = true;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
            _points[i] = _path.GetChild(i);
    }

    private void Update()
    {
        Transform target = _points[_currentPoint];
        Vector3 direction = target.position - transform.position;

        transform.position = Vector2.MoveTowards(transform.position,
                                                 target.position,
                                                 _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
                _currentPoint = 0;
        }

        Turn(direction);
    }

    public void Turn(Vector3 direction)
    {
        if (!IsFacingRight && direction.x > 0)
            Flip();
        else if (IsFacingRight && direction.x < 0)
            Flip();
    }

    private void Flip()
    {
        IsFacingRight = !IsFacingRight;
        Vector2 scaler = _transform.localScale;
        scaler.x *= -1;
        _transform.localScale = scaler;
    }
}
