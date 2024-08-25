using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHealthRegen : MonoBehaviour
{
    private PlayerHealth playerHealth;

    private void Start()
    {
        // Find the Player object and get the PlayerHealth component
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();

        // Simulate damage to the player (reduce health)
        playerHealth.currentHealth = playerHealth.maxHealth * 0.3f;  // Set current health to 30% of max

        // Log initial health
        Debug.Log("Initial Health: " + playerHealth.currentHealth);

        // Apply the health regeneration effect
        playerHealth.ApplyHealthRegeneration();
    }

    private void Update()
    {
        // Log the player's health every frame during regeneration
        Debug.Log("Current Health: " + playerHealth.currentHealth);
    }
}
