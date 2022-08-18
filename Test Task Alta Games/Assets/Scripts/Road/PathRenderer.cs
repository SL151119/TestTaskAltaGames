using UnityEngine;
public class PathRenderer : MonoBehaviour
{
    [Header("Finish Position")]
    [SerializeField] private Transform finishRoadPosition;

    [Header("Ball Script")]
    [SerializeField] private Ball ball;

    [Header("Offset")]
    [SerializeField] private Vector3 offset;

    private LineRenderer _lineRenderer;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        _lineRenderer.SetPosition(0, ball.transform.position);
        _lineRenderer.SetPosition(1, finishRoadPosition.position + offset);
        _lineRenderer.startWidth = ball.transform.localScale.x;
        _lineRenderer.endWidth = ball.transform.localScale.x;
    }
}
