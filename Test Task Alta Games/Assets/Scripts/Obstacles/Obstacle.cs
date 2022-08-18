using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [Header("Infection")]
    [SerializeField] private float _infectionTime;
    [SerializeField] private GameObject _infectionFX;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Infect()
    {
        StartCoroutine(DestroyObstacle());
    }

    private IEnumerator DestroyObstacle()
    {
        _animator.SetTrigger("Infect");
        while (_infectionTime > 0)
        {
            _infectionTime -= Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();

        }
        GameObject infectFX = Instantiate(_infectionFX, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
        Destroy(infectFX, 1);
        Destroy(gameObject);
    }
}
