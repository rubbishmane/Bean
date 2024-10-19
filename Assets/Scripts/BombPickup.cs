using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;
public class BombPickup : AttributesSync
{
    public GameManager gameManager;  // Reference to the GameManager
    public SpawnPlayers spawnScript;
    void Start()
    {
        
       
    }
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && spawnScript.theTerroristsName == Multiplayer.Instance.Me.Name)
        {
            InvokeRemoteMethod("ONTriggerEnterFunc", UserId.AllInclusive);
        }
        else if(spawnScript == null)
        {
            Debug.Log("SpawnScript is Null");
        }
        else if(spawnScript.terrorist == null)
        {
            Debug.Log("terrorist not set");
        }
        else if(spawnScript.terrorist != Multiplayer.Instance.Me)
        {
            Debug.Log("You are not the terrorist");
        }
    }
    [SynchronizableMethod]
    void ONTriggerEnterFunc()
    {
        Debug.Log("Trigger Enter");
        // Check if the player is the terrorist and they collide with the bomb   
        gameManager.BombPickedUp();  // Call GameManager to update bomb pickup status
        Destroy(gameObject);         // Destroy the bomb after it's picked up
    }
    
}
