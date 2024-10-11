using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    [SerializeField]
    private Color baseObjColor;
    [SerializeField]
    private Renderer objRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        objRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Plateau")) {
            objRenderer.material.color = Color.red;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Plateau"))
        {
            objRenderer.material.color = baseObjColor;
        }
    }
}
