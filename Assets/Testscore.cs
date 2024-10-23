using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Testscore : MonoBehaviour
{
    [SerializeField]
    private Color baseObjColor;
    [SerializeField]
    private Renderer objRenderer;
    [SerializeField]
    private GameObject pouletPrefab;
    public TextMeshProUGUI scoreText;
    private int scoreID = 0;

    // Start is called before the first frame update
    void Start()
    {
        //objRenderer = GetComponent<Renderer>();
        //objRenderer.material.SetFloat("_Mode", 3);
        //objRenderer.material.EnableKeyword("_ALPHABLEND_ON");
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (!other.CompareTag("Plateau"))
        {
            //Color transparentRed = new Color(1f, 0f, 0f, 0.3f);
            //objRenderer.material.color = transparentRed;
            Destroy(pouletPrefab);
            scoreID += 100;
            scoreText.text = scoreID.ToString();
            Instantiate(pouletPrefab, new Vector3(46, 1, 2), Quaternion.identity);

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
