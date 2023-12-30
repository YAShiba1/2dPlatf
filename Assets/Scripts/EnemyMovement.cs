using UnityEngine;

public class EnemyMovement : Movement
{
    [SerializeField] private Transform _path;
    [SerializeField] private Transform _player;
    [SerializeField] private float _chaseDistance;

    private Transform[] _points;
    private int _currentPoint;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, _player.position) < _chaseDistance)
        {
            Chase();
        }
        else
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        Transform target = _points[_currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _currentPoint++;

            Flip();

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }

    private void Chase()
    {
        if(transform.position.x > _player.position.x)
        {
            transform.position += Vector3.left * _speed * Time.deltaTime;

            if (_isFacingRight == false)
            {
                Flip();
            }
        }

        if (transform.position.x < _player.position.x)
        {
            transform.position += Vector3.right * _speed * Time.deltaTime;

            if (_isFacingRight)
            {
                Flip();
            }
        }
    }
}
