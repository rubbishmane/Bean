using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Alteruna;
public class ExitPad : MonoBehaviour
{
    public GameManager gameManager;  // Reference to the GameManager

    void OnTriggerEnter(Collider other)
    {
        // Check if the terrorist player reaches the exit
        if (other.CompareTag("Player") && gameManager.IsTerrorist())
        {
            gameManager.OnTerroristReachExit();  // Trigger room transition
        }
    }
}
