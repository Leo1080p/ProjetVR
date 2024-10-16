using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFox2 : MonoBehaviour
{
    public float movementSpeed = 2f;
    private Rigidbody rb;
    private bool inputDetecte = false;
    private Camera mainCamera;
    public float cameraDistance = 10f;      // Distance fixe entre la caméra et la mascotte
    public float cameraHeight = 2.72f;
    private bool hasResetPosition = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
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
            //mainCamera.transform.Rotate(0, 90, 0);
            //mainCamera.transform.LookAt(transform);

        }
        if (horizontalInput < 0 && inputDetecte == false)
        {
            inputDetecte = true;
            transform.Rotate(0, -90, 0);
            //mainCamera.transform.Rotate(0, -90, 0);
            //mainCamera.transform.LookAt(transform);
        }
        if (horizontalInput == 0)
        {
            inputDetecte = false;
        }
        if (mainCamera != null)
        {
            // Calcule la nouvelle position de la caméra
            Vector3 cameraPosition = transform.position - transform.forward * cameraDistance; // Positionne la caméra à une distance fixe derrière
            cameraPosition.y += transform.position.y + cameraHeight; // Ajoute la hauteur

            // Met à jour la position de la caméra
            mainCamera.transform.position = cameraPosition; 
            // Oriente la caméra pour qu'elle regarde la mascotte
            mainCamera.transform.LookAt(transform.position + Vector3.up * cameraHeight);
        }

        //rb.MovePosition(movement);
        transform.Translate(-Vector3.forward *Time.deltaTime*movementSpeed);
        //transform.Translate(forwardMovement);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        /*if(other.CompareTag("Enclos")){
            transform.position = new Vector3(48, 1, 0);
        }*/
        if (other.CompareTag("EnclosHaut") || other.CompareTag("EnclosHaut") || other.CompareTag("EnclosHaut") || other.CompareTag("EnclosHaut") && !hasResetPosition)
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
