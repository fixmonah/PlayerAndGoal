using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Gun _gun;
    [SerializeField] private GoalPool _goalPool;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && _gun.ReadyToShoot())
        {
            _gun.Shoot(_goalPool.GetNextGoalTransform());
        }
        if (Input.touchCount > 0 && _gun.ReadyToShoot())
        {
            _gun.Shoot(_goalPool.GetNextGoalTransform());
        }
    }
}
