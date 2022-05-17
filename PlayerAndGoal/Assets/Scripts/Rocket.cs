using UnityEngine;

public class Rocket : MonoBehaviour
{
    public Transform _terget;
    private float _rotationSpeed;
    private float _movementSpeed;
    private bool _moveOrder = false;

    public void Init(Transform targetPoint, float rotationSpeed, float moveSpeed)
    {
        _terget = targetPoint;
        _rotationSpeed = rotationSpeed;
        _movementSpeed = moveSpeed;
        _moveOrder = true;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject == _terget.gameObject)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (_moveOrder)
        {
            Quaternion rotTarget = Quaternion.LookRotation(_terget.position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotTarget, Time.deltaTime * _rotationSpeed);
            transform.position += transform.forward * Time.deltaTime * _movementSpeed;
        }
    }
}
