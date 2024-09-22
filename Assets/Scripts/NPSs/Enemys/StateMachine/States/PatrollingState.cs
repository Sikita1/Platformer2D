using UnityEngine;

public class PatrollingState : State
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    [SerializeField] private Turning _turning;

    private Transform[] _points;
    private int _currentPoint;

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
        if (_turning.FacingRight && direction.x > 0)
            _turning.Flip();
        else if (_turning.FacingRight == false && direction.x < 0)
            _turning.Flip();
    }
}
