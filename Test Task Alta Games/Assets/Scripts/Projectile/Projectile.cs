using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile")]
    [SerializeField] private float _shootPower;
    [SerializeField] private Vector3 _offset;

    private Rigidbody _rigidbody;
    private Transform _finish;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Shoot()
    {
        Vector3 shootDirection = _finish.position - transform.position;
        shootDirection += _offset;
        _rigidbody.AddForce(shootDirection * _shootPower, ForceMode.Impulse);
    }

    public void SetTargetPosition(Transform target)
    {
        _finish = target;
    }

    public void IncreaseSize()
    {
        transform.localScale = new Vector3(transform.localScale.x + Time.deltaTime,
                                           transform.localScale.y + Time.deltaTime,
                                           transform.localScale.z + Time.deltaTime);
    }
}
