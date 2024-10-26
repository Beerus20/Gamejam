using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 _offset;
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime = 0.3f;
    private Vector3 _currentVelocity = Vector3.zero;
    [SerializeField] private float movementThreshold = 0.1f; // Threshold to determine if the player is moving

    private void Awake()
    {
        _offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        // Assuming the target has a Rigidbody or a script that defines its velocity
        Rigidbody targetRigidbody = target.GetComponent<Rigidbody>();
        
        // Check if the target is moving
        if (targetRigidbody != null && targetRigidbody.velocity.magnitude > movementThreshold)
        {
            Vector3 targetPosition = target.position + _offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
        }
        // If the target isn't moving, the camera position remains unchanged
    }
}
