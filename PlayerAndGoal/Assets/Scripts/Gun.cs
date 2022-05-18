using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Rocket _rocket;
    [SerializeField] private Transform _spawnPoint;

    float _rocketRotationSpeed;
    float _rocketMovementSpeed;
    float _reloadTime;

    bool _readyToShoot = true;

    #region Set / Get
    public void SetRocketRotationSpeed(float speed) { _rocketRotationSpeed = speed; }
    public void SetRocketMovementSpeed(float speed) { _rocketMovementSpeed = speed; }
    public void SetReloadedTime(float seconds) { _reloadTime = seconds; }

    public bool ReadyToShoot() { return _readyToShoot; }
    #endregion

    public void Init(float rocketRotationSpeed, float rocketMovementSpeed, float reloadedTime)
    {
        _reloadTime = reloadedTime;
        _rocketMovementSpeed = rocketMovementSpeed;
        _rocketRotationSpeed = rocketRotationSpeed;
    }

    private void Start()
    {
        _readyToShoot = true;
    }

    public void Shoot(Transform terget)
    {
        if (_readyToShoot)
        {
            Rocket rocket = Instantiate(_rocket, _spawnPoint);
            rocket.gameObject.name = "Rocket";
            rocket.Init(terget, _rocketRotationSpeed, _rocketMovementSpeed);

            StartCoroutine(Reloaded());
        }
    }

    IEnumerator Reloaded()
    {
        _readyToShoot = false;
        yield return new WaitForSeconds(_reloadTime);
        _readyToShoot = true;
    }
}
