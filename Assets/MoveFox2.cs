using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFox2 : MonoBehaviour
{
    public float movementSpeed = 2f;
    private Rigidbody rb;
    private bool inputDetecte = false;
    private bool hasResetPosition = false;
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
            // Calcule la nouvelle position de la cam�ra
            Vector3 cameraPosition = transform.position + transform.forward * cameraDistance; // Positionne la cam�ra � une distance fixe derri�re
            cameraPosition.y += transform.position.y + cameraHeight; // Ajoute la hauteur

            // Met � jour la position de la cam�ra
            mainCamera.transform.position = cameraPosition;
            // Oriente la cam�ra pour qu'elle regarde la mascotte
            mainCamera.transform.LookAt(transform.position + Vector3.up * cameraHeight);
            
        }*/

        //rb.MovePosition(movement);
        transform.Translate(-Vector3.forward *Time.deltaTime*movementSpeed);
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
            transform.position = new Vector3(48,1,0);
            hasResetPosition = true;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        hasResetPosition = false;
    }
}
