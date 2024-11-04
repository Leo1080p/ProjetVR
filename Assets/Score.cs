using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Score : MonoBehaviour
{
    [SerializeField]
    private int score = 0;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Plateau") || !other.CompareTag("EnclosHaut") || !other.CompareTag("EnclosBas") || !other.CompareTag("EnclosGauche") || !other.CompareTag("EnclosDroit"))
        {
            score += 100;
            //scoreText.text = score.ToString();
        }
    }
}
