using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;
public class BombPickup : MonoBehaviour
{
    public GameManager gameManager;  // Reference to the GameManager

    void OnTriggerEnter(Collider other)
    {
        // Check if the player is the terrorist and they collide with the bomb
        if (other.CompareTag("Player") && gameManager.IsTerrorist())
        {
            gameManager.BombPickedUp();  // Call GameManager to update bomb pickup status
            Destroy(gameObject);         // Destroy the bomb after it's picked up
        }
    }
}
