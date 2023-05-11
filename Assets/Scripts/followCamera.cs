using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCamera : MonoBehaviour
{
    public Transform target;            // The player object to follow
    public float smoothSpeed = 0.125f;  // The speed at which the camera moves towards the target

    private Vector3 offset;             // The initial offset between the camera and the target

    private void Start()
    {
        // Calculate the initial offset between the camera and the target
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        // Calculate the target position for the camera
        Vector3 desiredPosition = target.position + offset;

        // Move the camera smoothly towards the target position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
