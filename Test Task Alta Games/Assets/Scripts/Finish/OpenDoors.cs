using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter (Collider other)
    {
        if (other.TryGetComponent(out Ball ball))
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        _animator.SetTrigger("OpenDoor");
    }

    public void CloseDoor()
    {
        _animator.SetTrigger("CloseDoor");
    }
}
