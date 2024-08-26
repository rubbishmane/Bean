using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHerion : MonoBehaviour
{
    public FPSController fpsController; // Reference to the FPSController script
    public PlayerHealth playerHealth;   // Reference to the PlayerHealth script

    public float speedBoostAmount = 10f;
    public float speedBoostDuration = 5f;

    public float healthBoostAmount = 50f;
    public float healthBoostDuration = 10f;

    private bool isSpeedBoostActive = false;
    private bool isHealthBoostActive = false;

    private float originalWalkSpeed;
    private float originalRunSpeed;

    private void Start()
    {
        // Store the original speeds
        originalWalkSpeed = fpsController.walkSpeed;
        originalRunSpeed = fpsController.runSpeed;
    }

    public void ApplySpeedBoost()
    {
        if (!isSpeedBoostActive)
        {
            StartCoroutine(SpeedBoost());
        }
    }

    public void ApplyHealthBoost()
    {
        if (!isHealthBoostActive)
        {
            StartCoroutine(HealthBoost());
        }
    }

    private IEnumerator SpeedBoost()
    {
        isSpeedBoostActive = true;

        // Increase both walking and running speeds
        fpsController.walkSpeed += speedBoostAmount;
        fpsController.runSpeed += speedBoostAmount;

        yield return new WaitForSeconds(speedBoostDuration);

        // Revert to original speeds
        fpsController.walkSpeed = originalWalkSpeed;
        fpsController.runSpeed = originalRunSpeed;

        isSpeedBoostActive = false;
    }

    private IEnumerator HealthBoost()
    {
        isHealthBoostActive = true;

        // Store original max health
        float originalMaxHealth = playerHealth.maxHealth;

        // Increase max health and current health
        playerHealth.maxHealth += healthBoostAmount;
        playerHealth.currentHealth = Mathf.Min(playerHealth.currentHealth + healthBoostAmount, playerHealth.maxHealth);

        yield return new WaitForSeconds(healthBoostDuration);

        // Adjust current health when boost ends, in case the player took damage
        float healthAfterBoostEnds = Mathf.Clamp(playerHealth.currentHealth, 0f, originalMaxHealth);

        // Revert to original max health and clamp current health accordingly
        playerHealth.maxHealth = originalMaxHealth;
        playerHealth.currentHealth = healthAfterBoostEnds;

        isHealthBoostActive = false;
    }

    // You can create additional methods or logic to trigger both boosts at the same time
    public void ApplyBothBoosts()
    {
        ApplySpeedBoost();
        ApplyHealthBoost();
    }
}

