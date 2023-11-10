using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsulScaleChange : MonoBehaviour
{
    [SerializeField] private float _speedScale;

    private Transform _capsule;

    private Vector3 _startScale;
    private bool _isScale = true;

    private void Awake()
    {
        _capsule = GetComponent<Transform>();
        _startScale = new Vector3(_capsule.localScale.x, _capsule.localScale.y, _capsule.localScale.z);
    }

    void Update()
    {
        CapsulChangeScale();
    }

    private void CapsulChangeScale()
    {
        Vector3 targetScale = new Vector3(2.5f, 2.5f, 2.5f);
        float scaleSpeedDeltaTime = _speedScale * Time.deltaTime;

        if (_isScale)
        {
            _capsule.localScale = new Vector3(_capsule.localScale.x + scaleSpeedDeltaTime,
                _capsule.localScale.y + scaleSpeedDeltaTime, _capsule.localScale.z + scaleSpeedDeltaTime);

            _isScale = _capsule.localScale.x <= targetScale.x;
        }
        else
        {
            _capsule.localScale = new Vector3(_capsule.localScale.x - scaleSpeedDeltaTime,
                _capsule.localScale.y - scaleSpeedDeltaTime, _capsule.localScale.z - scaleSpeedDeltaTime);

            _isScale = _capsule.localScale.x <= _startScale.x;
        }
    }
}
