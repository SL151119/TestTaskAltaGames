using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] private Finish finish;
    [SerializeField] private OpenDoors openDoors;
    [SerializeField] private SpawnObstacle spawnObstacle;

    private void OnEnable()
    {
        ball.Dead += OnPlayerDead;
        finish.Reached += OnTargetReached;
    }

    private void OnDisable()
    {
        ball.Dead -= OnPlayerDead;
        finish.Reached -= OnTargetReached;
    }

    private void Start()
    {
        spawnObstacle.ResetObstacles();
        ball.ResetPlayer();
    }

    private void RestartLevel()
    {
        spawnObstacle.ResetObstacles();
        ball.ResetPlayer();
        openDoors.CloseDoor();
    }

    private void OnTargetReached()
    {
        RestartLevel();
    }
 
    private void OnPlayerDead()
    {
        RestartLevel();
    }
}
