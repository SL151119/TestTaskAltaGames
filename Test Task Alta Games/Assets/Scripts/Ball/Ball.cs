using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    [Header("Position")]
    [SerializeField] private Transform startPosition;

    [Header("Size")]
    [SerializeField] private float startSize;
    [SerializeField] private float minSize;

    private float _currentSize;
    private float _normalSize;

    public event UnityAction Dead;

    private void Start()
    {
        transform.position = startPosition.position;
    }
    public void ResetPlayer()
    {
        SetStartSize();
        transform.position = startPosition.position;
    }

    private void SetStartSize()
    {
        _currentSize = startSize;
        transform.localScale = Vector3.one * startSize;
        _normalSize = _currentSize / startSize;
    }

    public void ReduceBallSize()
    {
        transform.localScale = new Vector3(transform.localScale.x - Time.deltaTime,
                                           transform.localScale.y - Time.deltaTime,
                                           transform.localScale.z - Time.deltaTime);
        _currentSize = transform.localScale.x;

        if (IsMinimumSize())
        {
            Dead?.Invoke();
        }
    }

    private bool IsMinimumSize()
    {
        _normalSize = _currentSize / startSize;
        return _normalSize < minSize;
    }
}
