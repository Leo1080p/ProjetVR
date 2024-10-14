using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Transform positionA;
    public Transform positionB;
    public float speed = 0.2f;
    //public float t = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(positionA.position, positionB.position, Mathf.PingPong(Time.time*speed,1));
    }
}
