using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class play : MonoBehaviour
{
    public void BTNJouer()
    {
        Debug.Log("Btn clique");
        SceneManager.LoadScene("MyScene");
    }
}
