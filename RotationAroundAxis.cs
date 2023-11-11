using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAroundAxis : MonoBehaviour
{
    [SerializeField] private int _speedRotationSqare = 90;

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, _speedRotationSqare), _speedRotationSqare * Time.deltaTime);
    }
}
