using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform targetObject;
    public float smoothSpeed = 0.125f;
    private Vector3 initialOffset;
    private Vector3 cameraPosition;
    private Vector3 smoothedPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialOffset = transform.position - targetObject.position;
    }

    void LateUpdate()
    {
        cameraPosition = targetObject.position + initialOffset;
        smoothedPosition = Vector3.Lerp(transform.position, cameraPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(smoothedPosition);
    }
}