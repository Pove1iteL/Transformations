using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultifunctionalSquare : MonoBehaviour
{

    [SerializeField] private float _speedScaleSquare;
    [SerializeField] private float _moveSpeedSqare = 3;
    [SerializeField] private int _speedRotationSqare = 90;

    private Transform _square;
    private Vector3 _startPositionSquare;
    private bool _isPathAchive = true;

    private void Awake()
    {
        _square = GetComponent<Transform>();
        _startPositionSquare = new Vector3(_square.position.x, _square.position.y);
    }

    private void Update()
    {
        StatrtMultifunctionalSquare();
    }

    private void StatrtMultifunctionalSquare()
    {
        int targetPoint = -21;
        float speedScaleDeltaTime = _speedScaleSquare * Time.deltaTime;

        Vector3 squareScale = new Vector3(_square.localScale.x, _square.localScale.y, _square.localScale.z);
        Vector3 target = new Vector3(targetPoint, _square.position.y);

        _square.Rotate(new Vector3(0, 0, _speedRotationSqare), _speedRotationSqare * Time.deltaTime);

        if (_isPathAchive)
        {
            Move(target);

            ChangeScale(squareScale, speedScaleDeltaTime, false);

            _isPathAchive = _square.position == target ? false : true;
        }
        else
        {
            Move(_startPositionSquare);

            ChangeScale(squareScale, speedScaleDeltaTime,true);

            _isPathAchive = _square.position == _startPositionSquare ? true : false;
        }
    }

    private void ChangeScale(Vector3 vector, float speedScaleDeltaTime, bool isBack)
    {
        if (isBack)
        {
            _square.localScale = new Vector3(vector.x - speedScaleDeltaTime,
                                             vector.y - speedScaleDeltaTime,
                                             vector.z - speedScaleDeltaTime);
        }
        else
        {
            _square.localScale = new Vector3(vector.x + speedScaleDeltaTime,
                                             vector.y + speedScaleDeltaTime,
                                             vector.z + speedScaleDeltaTime);
        }
    }

    private void Move(Vector3 target)
    {
        _square.position = Vector2.MoveTowards(_square.position, target, _moveSpeedSqare * Time.deltaTime);
    }
}
