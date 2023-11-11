using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOfSize : MonoBehaviour
{
    [SerializeField] private float _speedScale;
    [SerializeField] private Vector3 _targetScale = new Vector3(2.5f, 2.5f, 2.5f);

    private Vector3 _startScale;
    private bool _isScale = true;

    private void Awake()
    {
        _startScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    private void Update()
    {
        MoveToTargetScale();
    }

    private void MoveToTargetScale()
    {
        if (_isScale)
        {
            ChangeScale(_targetScale);

            _isScale = transform.localScale.x < _targetScale.x;
        }
        else
        {
            ChangeScale(_startScale);

            _isScale = transform.localScale.x == _startScale.x;
        }
    }

    private void ChangeScale(Vector3 target)
    {
        float scaleSpeedDeltaTime = _speedScale * Time.deltaTime;

        transform.localScale = Vector3.MoveTowards(transform.localScale, target, scaleSpeedDeltaTime);
    }
}
