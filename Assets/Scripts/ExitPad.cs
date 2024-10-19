using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Alteruna;
public class ExitPad : MonoBehaviour
{
    int padDestination;
    public SpawnPlayers spawnScript;
    public GameManager gameManager;  // Reference to the GameManager

    void OnTriggerEnter(Collider other)
    {
        // Check if the terrorist player reaches the exit
        if (other.CompareTag("Player") && spawnScript.theTerroristsName == Multiplayer.Instance.Me.Name)
        {
            if(gameManager.bombPickedUp)
            {
                gameManager.OnTerroristReachExit();
            }
            else
            {
                Debug.Log("doesnt have bomb");
          }
              // Trigger room transition
        }
        else if(spawnScript == null)
        {
            Debug.Log("SpawnScript is Null on exit");
        }
        else if(spawnScript.terrorist == null)
        {
            Debug.Log("terrorist not set  on exit");
        }
        else if(spawnScript.terrorist != Multiplayer.Instance.Me)
        {
            Debug.Log("You are not the terrorist  on exit");
        }
    }
}
