using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [Header("Goals")]
    [SerializeField] private int _goalsCount;
    [SerializeField] private int _goalsRotationSpeed;
    [SerializeField] private GoalPool _goalPool;
    [Header("Gun")]
    [SerializeField] private float _rocketRotationSpeed;
    [SerializeField] private float _rocketMovementSpeed;
    [SerializeField] float _rocketReloadedTime;
    [SerializeField] Gun _gun;
    [Header("Apply settings")]
    [SerializeField] bool _apply;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Init());
    }

    private void Update()
    {
        if (_apply)
        {
            _goalPool.SetSpeed(_goalsRotationSpeed);
            _gun.SetReloadedTime(_rocketReloadedTime);
            _gun.SetRocketMovementSpeed(_rocketMovementSpeed);
            _gun.SetRocketRotationSpeed(_rocketRotationSpeed);

            _apply = false;
        }
    }

    IEnumerator Init() 
    {
        yield return new WaitForEndOfFrame();
        _goalPool.Init(_goalsCount, _goalsRotationSpeed);
        _gun.Init(_rocketRotationSpeed, _rocketMovementSpeed, _rocketReloadedTime);
    }
}
