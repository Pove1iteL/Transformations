using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementToPosition : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3;
    [SerializeField] private Vector3 _targetPosition;

    private Vector3 _startPositionCircle;
    private bool _isPathAchive = false;

    private void Awake()
    {
        _startPositionCircle = new Vector3(transform.position.x, transform.position.y);
    }

    private void Update()
    {
        MovePosition();
    }

    private void MovePosition()
    {
        if (_isPathAchive)
        {
            Move(_startPositionCircle);

            _isPathAchive = transform.position != _startPositionCircle;
        }
        else
        {
            Move(_targetPosition);

            _isPathAchive = transform.position == _targetPosition;
        }
    }

    private void Move(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, _moveSpeed * Time.deltaTime);
    }
}
