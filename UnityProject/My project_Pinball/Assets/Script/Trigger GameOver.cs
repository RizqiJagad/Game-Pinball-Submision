using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class TriggerGameOver : MonoBehaviour
{
    public Collider bola;

    private void OnTriggerEnter(Collider other)
    {
        if(other == bola)
        { 
            SceneManager.LoadScene("MainMenu");
        }
    }
}
