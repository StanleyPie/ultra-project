using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDucer : MonoBehaviour
{
    [Range(-55.6f, 46.86f)] public float value;
    public float maxAngle = 46.86f;
    public float minAngle = -55.6f;

    private void Update()
    {
        this.transform.rotation = Quaternion.Euler(0, 0, Mathf.Clamp(value, minAngle, maxAngle));
    }

}
