using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformTracker : MonoBehaviour
{

    public Transform target;
    public bool isPositionFollow = true;
    public bool isRotaionFollow = true;
    public Vector3 positionOffset;
    public Vector3 rotationOffset;
    public float positionSmoothSpeed = 0.125f;
    public float rotationSmoothSpeed = 0.125f;

    private void Update()
    {
        if (target == null)
            return;

        if (isPositionFollow)
        {

            Vector3 desiredPosition = target.position + target.rotation * positionOffset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, positionSmoothSpeed);
            transform.position = smoothedPosition;
        }

        if (isRotaionFollow)
        {
            Quaternion desiredRotation = target.rotation * Quaternion.Euler(rotationOffset);
            Quaternion smoothedRotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSmoothSpeed);
            transform.rotation = smoothedRotation;
        }
    }



}



