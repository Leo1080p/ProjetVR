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
        objRenderer.material.SetFloat("_Mode", 3);
        objRenderer.material.EnableKeyword("_ALPHABLEND_ON");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (!other.CompareTag("Plateau")) {
            Color transparentRed = new Color(1f, 0f, 0f, 0.3f);
            objRenderer.material.color = transparentRed;

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
