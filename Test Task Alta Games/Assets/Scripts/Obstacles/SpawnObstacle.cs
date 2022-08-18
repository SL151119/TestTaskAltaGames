using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    [Header("Obstacles")]
    [SerializeField] private GameObject obstaclesHolder;
    [SerializeField] private Obstacle obstaclePrefab;
    [SerializeField] private int _obstacleCount;

    [Header("Obstacles Spawn Position")]
    [SerializeField] private Transform _minPosition;
    [SerializeField] private Transform _maxPosition;

    [Header("Finish")]
    [SerializeField] private Finish finish;

    [Header("Ball")]
    [SerializeField] private Ball ball;


    private void Start()
    {
        ResetObstacles();
    }

    public void ResetObstacles()
    {
        foreach (Transform obstacle in obstaclesHolder.transform)
        {
            Destroy(obstacle.gameObject);
        }

        Vector3 targetPath = finish.transform.position - ball.transform.position;
        for (int i = 0; i < _obstacleCount; i++)
        {
            Obstacle obstacle = Instantiate(obstaclePrefab, obstaclesHolder.transform);
            obstacle.transform.position = GetPosition();
        }
    }

    private Vector3 GetPosition()
    {
        return new Vector3(Random.Range(_minPosition.position.x, _maxPosition.position.x),
                                       1,
                                       Random.Range(_minPosition.position.z, _maxPosition.position.z));
    }
}
