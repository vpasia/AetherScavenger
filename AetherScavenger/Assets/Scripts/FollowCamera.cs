using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offset;

    [SerializeField]
    private float smoothSpeed = 5f;



    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;

        if(Math.Abs(180 - target.localRotation.eulerAngles.z) < 170)
        {
            desiredPosition.x += Mathf.Clamp(180 - target.localRotation.eulerAngles.z, -30, 30);
        }

        if(Math.Abs(180 - target.localRotation.eulerAngles.x) < 165)
        {
            desiredPosition.y += Mathf.Clamp(180 - target.localRotation.eulerAngles.x, -50, 50);
        }


        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.fixedDeltaTime);

        transform.position = smoothedPosition;
        transform.LookAt(target);
    }
}
