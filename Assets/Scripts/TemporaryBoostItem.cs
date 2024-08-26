using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryBoostItem : MonoBehaviour
{
    public FPSController playerController;
    public PlayerHealth playerHealth;

    public float speedBoostMultiplier = 1.5f;  // 50% speed increase
    public int healthBoostAmount = 50;
    public float boostDuration = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))  // Example input for testing
        {
            // Apply health and speed boost
           // playerHealth.ApplyHealthBoost(healthBoostAmount);
           // playerController.ApplySpeedBoost(speedBoostMultiplier, boostDuration);
        }
    }



    /*private float originalSpeed;
    private int originalHealth;
    private bool isBoostActive = false;

    // Reference to the player's stats
    private Playerhealth playerhealth;

    void Start()
    {
        // Assume playerStats is a script attached to the player that handles health and speed
        playerStats = GetComponent<PlayerStats>();
    }

    public void UseItem()
    {
        if (isBoostActive) return; // Prevent multiple uses simultaneously

        originalHealth = playerStats.health;
        originalSpeed = playerStats.speed;

        // Apply the boosts
        playerStats.IncreaseHealth(50); // Increase health by 50 (example)
        playerStats.speed *= 1.5f; // Increase speed by 50%

        isBoostActive = true;

        // Start a coroutine to revert the changes after 10 seconds
        StartCoroutine(RevertBoosts());
    }

    private IEnumerator RevertBoosts()
    {
        yield return new WaitForSeconds(10);

        // Revert the changes
        playerStats.health = originalHealth;
        playerStats.speed = originalSpeed;

        isBoostActive = false;
    }*/
}

