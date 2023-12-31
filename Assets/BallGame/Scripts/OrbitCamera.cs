using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class OrbitCamera : MonoBehaviour
{
    [SerializeField] Transform focus = default;
    [SerializeField, Range(1f, 40f)] private float distance = 5f;
    [SerializeField, Min(0f)] private float focusRadius = 1f;
    private Vector3 focusPoint;

    private void Awake()
    {
        focusPoint = focus.position;
    }
    private void LateUpdate()
    {
        UpdateFocusPoint();
        Vector3 lookDirection = transform.forward;
        transform.localPosition = focusPoint - lookDirection * distance;
    }

    private void UpdateFocusPoint()
    {
        Vector3 targetPoint = focus.position;
        if (focusRadius > 0f)
        {
            float distance = Vector3.Distance(targetPoint, focusPoint);
            if (distance > focusRadius)
            {
                focusPoint = Vector3.Lerp(
                    targetPoint, focusPoint, focusRadius / distance
                );
            }
        }
        else
        {
            focusPoint = targetPoint;
        }
    }
}