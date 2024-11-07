using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveANDlife : MonoBehaviour
{
    public float movementSpeed = 2f;
    private Rigidbody rb;
    private bool inputDetecte = false;
    private bool hasResetPosition = false;

    public GameObject ViePlein1;
    public GameObject ViePlein2;
    public GameObject ViePlein3;
    public GameObject VieVide1;
    public GameObject VieVide2;
    public GameObject VieVide3;
    public TextMeshProUGUI TextGameOver;

    private int life = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forwardMovement = transform.forward * movementSpeed * Time.deltaTime;
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0 && inputDetecte == false)
        {
            inputDetecte = true;
            transform.Rotate(0, 90, 0);
        }
        if (horizontalInput < 0 && inputDetecte == false)
        {
            inputDetecte = true;
            transform.Rotate(0, -90, 0);
        }
        if (horizontalInput == 0)
        {
            inputDetecte = false;
        }
        /*if (mainCamera != null)
        {
            // Calcule la nouvelle position de la caméra
            Vector3 cameraPosition = transform.position + transform.forward * cameraDistance; // Positionne la caméra à une distance fixe derrière
            cameraPosition.y += transform.position.y + cameraHeight; // Ajoute la hauteur

            // Met à jour la position de la caméra
            mainCamera.transform.position = cameraPosition;
            // Oriente la caméra pour qu'elle regarde la mascotte
            mainCamera.transform.LookAt(transform.position + Vector3.up * cameraHeight);
            
        }*/

        //rb.MovePosition(movement);
        transform.Translate(-Vector3.forward * Time.deltaTime * movementSpeed);
        //transform.Translate(forwardMovement);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag + " : " + other.name);
        /*if(other.CompareTag("Enclos")){
            transform.position = new Vector3(48, 1, 0);
        }*/
        if (other.CompareTag("EnclosHaut") || other.CompareTag("EnclosBas") || other.CompareTag("EnclosGauche") || other.CompareTag("EnclosDroit") && !hasResetPosition)
        {
            transform.position = new Vector3(48, 1, 0);
            hasResetPosition = true;
            if (life == 1)
            {
                ViePlein1.SetActive(false);
                VieVide1.SetActive(true);
                life--;

                // Message gameOver
                TextGameOver.gameObject.SetActive(true);
                //yield WaitForSeconds(5);
                //SceneManager.LoadScene("MainMenu");
            }

            if (life == 2)
            {
                ViePlein2.SetActive(false);
                VieVide2.SetActive(true);
                life--;
            }

            if (life == 3)
            {
                ViePlein3.SetActive(false);
                VieVide3.SetActive(true);
                life--;
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        hasResetPosition = false;
    }
}
