using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 positionA = new Vector3(39.2f, 1.4f, -8.84f);
    public Vector3 positionB = new Vector3(39.2f, 1.4f, 8.84f);
    public Vector3 positionC = new Vector3(56.2f, 1.4f, 8.84f);
    public Vector3 positionD = new Vector3(56.2f, 1.4f, -8.84f);
    private Vector3 destination;
    public float treshold = 0.5f;
    public float speed = 2f;
    //public float t = 0;
    // Start is called before the first frame update
    private bool bougerDroite = false;
    private bool versC = false;
    private bool inputDetecte = false;
    public float intervalle = 2f;
    public float timeElapsed = 0.0f;
    private Vector3[] positions;
    private int currentIndex = 0;
    void Start()
    {
        positions = new Vector3[] { positionA, positionC, positionB, positionD };
        destination = positions[currentIndex];
    }
    void FixedUpdate()
    {
        // Détecter un appui unique sur la touche horizontale
        if (Input.GetAxis("Horizontal") > 0 && !inputDetecte)
        {
            AllerVersProchainePosition();
            inputDetecte = true;
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            inputDetecte = false;
        }
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.fixedDeltaTime);
        transform.LookAt(positions[(currentIndex-1)%positions.Length]);
    }
    void AllerVersProchainePosition()
    {
        currentIndex = (currentIndex + 1) % positions.Length;
        destination = positions[currentIndex];
    }
    void MoveTowardsDestination()
    {
        // Déplacement vers la destination en gardant l'axe Y constant
        Vector3 newPosition = Vector3.MoveTowards(transform.position, destination, speed * Time.fixedDeltaTime);
        newPosition.y = transform.position.y;  // Garder Y constant

        // Appliquer la nouvelle position
        transform.position = newPosition;
    }
}

