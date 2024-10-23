using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField]
    private GameObject pouletPrefab;
    [SerializeField]
    private Vector3 spawnVector = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        if (pouletPrefab == null) { 
        Instantiate(pouletPrefab, spawnVector, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
