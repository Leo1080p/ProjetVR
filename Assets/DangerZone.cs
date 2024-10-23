using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    [SerializeField]
    private Color baseObjColor;
    [SerializeField]
    private Renderer objRenderer;
    [SerializeField]
    private GameObject pouletPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        //objRenderer = GetComponent<Renderer>();
        //objRenderer.material.SetFloat("_Mode", 3);
        //objRenderer.material.EnableKeyword("_ALPHABLEND_ON");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (!other.CompareTag("Plateau")) {
            //Color transparentRed = new Color(1f, 0f, 0f, 0.3f);
            //objRenderer.material.color = transparentRed;
            Destroy(pouletPrefab);
            Instantiate(pouletPrefab, new Vector3(46,1,2), Quaternion.identity);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Plateau"))
        {
            Instantiate(pouletPrefab, Vector3.zero, Quaternion.identity);
            //objRenderer.material.color = baseObjColor;
        }
    }
}
