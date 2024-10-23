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
        initialOffset = new Vector3(2,2.55f,5) ;//transform.position;// - targetObject.position;
    }

    void LateUpdate()
    {
        cameraPosition = targetObject.rotation * initialOffset + targetObject.position;
        //       cameraPosition = targetObject.position + transform.forward*2.0f;
        
        transform.position = cameraPosition;
        transform.LookAt(targetObject);
        
    }
}
