using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [Header("Goals")]
    [SerializeField] private int _goalsCount;
    [SerializeField, Range(10, 100)] private int _goalsRotationSpeed;
    [SerializeField] private GoalPool _goalPool;
    [Header("Gun")]
    [SerializeField, Range(50, 200)] private float _rocketRotationSpeed;
    [SerializeField, Range(1, 10)] private float _rocketMovementSpeed;
    [SerializeField, Range(1, 10)] float _rocketReloadedTime;
    [SerializeField] Gun _gun;

    private int   _goalsRotationSpeedLast;
    private float _rocketRotationSpeedLast;
    private float _rocketMovementSpeedLast;
    private float _rocketReloadedTimeLast;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Init());
    }

    private void Update()
    {
        if (NeedUpdate())
        {
            _goalPool.SetSpeed(_goalsRotationSpeed);
            _gun.SetReloadedTime(_rocketReloadedTime);
            _gun.SetRocketMovementSpeed(_rocketMovementSpeed);
            _gun.SetRocketRotationSpeed(_rocketRotationSpeed);
        }
    }


    private bool NeedUpdate() 
    {
        bool answer = false;

        if (_goalsRotationSpeedLast != _goalsRotationSpeed)
        {
            answer = true;
            _goalsRotationSpeedLast = _goalsRotationSpeed;
        }
        if (_rocketRotationSpeedLast != _rocketRotationSpeed)
        {
            answer = true;
            _rocketRotationSpeedLast = _rocketRotationSpeed;
        }
        if (_rocketMovementSpeedLast != _rocketMovementSpeed)
        {
            answer = true;
            _rocketMovementSpeedLast = _rocketMovementSpeed;
        }
        if (_rocketReloadedTimeLast != _rocketReloadedTime)
        {
            answer = true;
            _rocketReloadedTimeLast = _rocketReloadedTime;
        }
        return answer;
    }


    IEnumerator Init() 
    {
        yield return new WaitForEndOfFrame();
        _goalPool.Init(_goalsCount, _goalsRotationSpeed);
        _gun.Init(_rocketRotationSpeed, _rocketMovementSpeed, _rocketReloadedTime);
    }
}
