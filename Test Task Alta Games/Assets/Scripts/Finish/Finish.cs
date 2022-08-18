using UnityEngine;
using UnityEngine.Events;

public class Finish : MonoBehaviour
{
    public event UnityAction Reached;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Obstacle obstacle) || other.TryGetComponent(out Projectile projectile))
        {
            Destroy(other.gameObject);
        }
        if (other.TryGetComponent(out Ball ball))
        {
            Reached?.Invoke();
        }
    }
}
