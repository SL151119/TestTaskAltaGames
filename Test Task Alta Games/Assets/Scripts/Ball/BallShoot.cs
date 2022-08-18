using System.Collections;
using UnityEngine;

public class BallShoot : MonoBehaviour
{
    [SerializeField] private Projectile projectile;
    [SerializeField] private Transform finish;
    [SerializeField] private Transform _shootPoint;

    private Ball _ball;
    private Projectile _projectile;

    public bool _isBallIncreasing { get; private set; }


    private void Awake()
    {
        _ball = GetComponent<Ball>();
    }

    private void OnEnable()
    {
        _ball.Dead += OnPlayerDead;
    }
    private void OnDisable()
    {
        _ball.Dead -= OnPlayerDead;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _projectile = CreateNewBall();
            StartResizeBall(_projectile);
        }
        if (Input.GetMouseButtonUp(0))
        {
            StopResizeBall(_projectile);
            _projectile.SetTargetPosition(finish);
            if (_projectile != null)
            {
                _projectile.Shoot();
            }
        }
    }

    private Projectile CreateNewBall()
    {
      return Instantiate(projectile, _shootPoint.position, Quaternion.identity);
    }

    private void StartResizeBall(Projectile projectile)
    {
        if (projectile != null)
        {
            _isBallIncreasing = true;
            StartCoroutine(ResizeBall(projectile));
        }
    }

    private void StopResizeBall(Projectile projectile)
    {
        if (projectile != null)
        {
            _isBallIncreasing = false;
            StopCoroutine(ResizeBall(projectile));
        }
    }

    private void OnPlayerDead()
    {
        StopResizeBall(_projectile);
        Destroy(_projectile.gameObject);
    }

    private IEnumerator ResizeBall(Projectile projectile)
    {
        while (_isBallIncreasing)
        {
            _ball.ReduceBallSize();
            projectile.IncreaseSize();
            yield return new WaitForFixedUpdate();
        }
    }
}
