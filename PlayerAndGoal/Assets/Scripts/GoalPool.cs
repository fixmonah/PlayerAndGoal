using System.Collections.Generic;
using UnityEngine;

public class GoalPool : MonoBehaviour
{
    [SerializeField] private GameObject _goalPrefab;
    [SerializeField] private GameObject _centerObject;
    private float _centerRotationSpeed;
    private Vector3 _centerRotationVector = Vector3.down;
    private List<GameObject> _goals = new List<GameObject>();
    private int _nextGoalIndex = 0;

    public void Init(int goalCount, float rotationSpeed) 
    {
        _centerRotationSpeed = rotationSpeed;
        CreateGoals(goalCount);
    }

    public void SetSpeed(float speed) 
    {
        _centerRotationSpeed = speed;
    }

    public Transform GetNextGoalTransform()
    {
        if (_nextGoalIndex >= _goals.Count)
        {
            _nextGoalIndex = 0;
        }
        Transform answer = _goals[_nextGoalIndex].transform.GetChild(0).transform;
        _nextGoalIndex++;
        return answer;
    }

    private void CreateGoals(int count) 
    {
        for (int i = 0; i < count; i++)
        {
            GameObject goalCenter = new GameObject();
            goalCenter.name = "GoalCenter";
            goalCenter.transform.SetParent(_centerObject.transform);
            goalCenter.transform.position = Vector2.zero;
            goalCenter.transform.rotation = Quaternion.identity;

            Instantiate(_goalPrefab, new Vector3(5f, 0f, 0f), Quaternion.identity, goalCenter.transform);
            _goals.Add(goalCenter);
        }

        float rotationAngle = (float)360 / _goals.Count;
        for (int i = 0; i < _goals.Count; i++)
        {
            _goals[i].transform.localRotation = Quaternion.Euler(new Vector3(0f, i * rotationAngle, 0f));
        }
    }

    private void Update()
    {
        _centerObject.transform.Rotate(_centerRotationVector * _centerRotationSpeed * Time.deltaTime);
    }
}
