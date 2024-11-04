using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    [SerializeField]
    private Color baseObjColor;
    [SerializeField]
    private Renderer objRenderer;
    [SerializeField]
    private GameObject pouletPrefab;
    [SerializeField]
    //private int score=0;
    //public TextMeshProUGUI scoreText;
    private GameObject currentpoulet;

    // Start is called before the first frame update
    void Start()
    {
        //objRenderer = GetComponent<Renderer>();
        //objRenderer.material.SetFloat("_Mode", 3);
        //objRenderer.material.EnableKeyword("_ALPHABLEND_ON");
        
        //scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (!other.CompareTag("Plateau") || !other.CompareTag("Untagged")) {
            //Color transparentRed = new Color(1f, 0f, 0f, 0.3f);
            //objRenderer.material.color = transparentRed;
            
            Destroy(pouletPrefab);
            //score += 100;
            //scoreText.text = score.ToString();
            currentpoulet = Instantiate(pouletPrefab, new Vector3(Random.Range(41f,55f),0.4f,Random.Range(-7.2f,7.2f)), Quaternion.identity);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Plateau"))
        {
            
            //objRenderer.material.color = baseObjColor;
        }
    }
}
