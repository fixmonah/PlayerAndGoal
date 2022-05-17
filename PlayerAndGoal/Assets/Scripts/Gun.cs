using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Rocket _rocket;
    [SerializeField] private Transform _spawnPoint;

    float _rocketRotationSpeed;
    float _rocketMovementSpeed;
    float _reloadedTime;

    bool _orderToShoot = true;

    #region Set
    public void SetRocketRotationSpeed(float speed) { _rocketRotationSpeed = speed; }
    public void SetRocketMovementSpeed(float speed) { _rocketMovementSpeed = speed; }
    public void SetReloadedTime(float seconds) { _reloadedTime = seconds; }
    #endregion

    public void Init(float rocketRotationSpeed, float rocketMovementSpeed, float reloadedTime)
    {
        _reloadedTime = reloadedTime;
        _rocketMovementSpeed = rocketMovementSpeed;
        _rocketRotationSpeed = rocketRotationSpeed;
    }

    private void Start()
    {
        _orderToShoot = true;
    }

    public void Shoot(Transform terget)
    {
        if (_orderToShoot)
        {
            Rocket rocket = Instantiate(_rocket, _spawnPoint);
            rocket.gameObject.name = "Rocket";
            rocket.Init(terget, _rocketRotationSpeed, _rocketMovementSpeed);

            StartCoroutine(Reloaded());
        }
    }

    IEnumerator Reloaded()
    {
        _orderToShoot = false;
        yield return new WaitForSeconds(_reloadedTime);
        _orderToShoot = true;
    }
}
