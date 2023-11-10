using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeedCircle = 3;

    private Transform _circle;
    private Vector3 _startPositionCircle;
    private bool _isPathAchive = false;

    private void Awake()
    {
        _circle = GetComponent<Transform>();
        _startPositionCircle = new Vector3(_circle.position.x, _circle.position.y);
    }

    private void Update()
    {
        MoveCircle();
    }

    private void MoveCircle()
    {
        int targetPoint = 3;
        Vector3 target = new Vector3(_circle.position.x, targetPoint);

        if (_isPathAchive)
        {
            Move(_startPositionCircle);

            _isPathAchive = _circle.position != _startPositionCircle;
        }
        else
        {
            Move(target);

            _isPathAchive = _circle.position == target;
        }
    }

    private void Move(Vector3 target)
    {
        _circle.position = Vector2.MoveTowards(_circle.position, target, _moveSpeedCircle * Time.deltaTime);
    }
}
