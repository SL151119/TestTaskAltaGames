using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [Header("Ball Speed")]
    [SerializeField] private float speed;

    [Header("Finish Script")]
    [SerializeField] private Finish finishScript;

    [Header("Distance")]
    [SerializeField] private float minDistanceToMove;

    private BallShoot _ballShootScript;
    private int _obstacleLayerIndex;
    private int _layerMask;

    public Vector3 _direction { get; private set; }


    private void Start()
    {
        _ballShootScript = GetComponent<BallShoot>();
        SetStartValues();
        InitializeLayerMask();
    }

    private void FixedUpdate()
    {
        BallMove();
    }

    private void SetStartValues()
    {
        _direction = finishScript.transform.position - transform.position;
        _direction = new Vector3(_direction.x, transform.position.y, _direction.z);
        transform.rotation = Quaternion.LookRotation(_direction);
    }
    private void InitializeLayerMask()
    {
        _obstacleLayerIndex = LayerMask.NameToLayer("Obstacle");
        _layerMask = 1 << _obstacleLayerIndex;
    }
    private void BallMove()
    {
        if (!_ballShootScript._isBallIncreasing)
        {
            if (!Physics.SphereCast(transform.position, transform.localScale.x, _direction, out RaycastHit hit, minDistanceToMove, _layerMask))
            {
                transform.position = Vector3.MoveTowards(transform.position, _direction, speed * Time.fixedDeltaTime);
            }
        }
    }
}
