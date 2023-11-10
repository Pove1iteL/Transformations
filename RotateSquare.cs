using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSquare : MonoBehaviour
{
    [SerializeField] private int _speedRotationSqare = 90;
    private Transform _square;

    private void Awake()
    {
        _square = GetComponent<Transform>();
    }

    private void Update()
    {
        _square.Rotate(new Vector3(0, 0, _speedRotationSqare), _speedRotationSqare * Time.deltaTime);
    }
}
