using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    private List<Obstacle> _obstaclesList = new List<Obstacle>();

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Obstacle obstacle))
        {
            Explode();
            Destroy(gameObject);
        }
        else if (collision.gameObject.TryGetComponent(out Finish finish))
        {
            Destroy(gameObject);
        }
    }

    private void Explode()
    {
        foreach (Obstacle obstacle in _obstaclesList)
        {
            obstacle.Infect();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Obstacle obstacle))
        {
            _obstaclesList.Add(obstacle);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Obstacle obstacle))
        {
            _obstaclesList.Remove(obstacle);
        }
    }
}
