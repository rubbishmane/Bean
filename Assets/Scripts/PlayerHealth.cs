using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    public float healthBoostAmount = 50f; // The amount by which max health is boosted
    public float healthBoostDuration = 10f; // Duration of the health boost
    
    private bool isHealthBoostActive = false;
    private float originalMaxHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void ApplyHealthRegeneration()
    {
        // Start the health regeneration process over 10 seconds for 50% of max health.
        StartCoroutine(RegenerateHealthOverTime(10f, maxHealth * 0.5f));
    }

    public void ApplyHealthBoost()
    {
        if (!isHealthBoostActive)
        {
            StartCoroutine(HealthBoost());
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        Debug.Log("Player took damage: " + damage + ". Current Health: " + currentHealth);
    }

    private IEnumerator HealthBoost()
    {
        isHealthBoostActive = true;
        originalMaxHealth = maxHealth;

        // Increase max health and current health
        maxHealth += healthBoostAmount;
        currentHealth = Mathf.Min(currentHealth + healthBoostAmount, maxHealth);

        Debug.Log("Health Boost Activated. Current Health: " + currentHealth);

        yield return new WaitForSeconds(healthBoostDuration);

        // Adjust current health when boost ends, in case the player took damage
        float healthAfterBoostEnds = Mathf.Clamp(currentHealth, 0f, originalMaxHealth);

        // Revert to original max health and clamp current health accordingly
        maxHealth = originalMaxHealth;
        currentHealth = healthAfterBoostEnds;

        Debug.Log("Health Boost Ended. Current Health: " + currentHealth);

        isHealthBoostActive = false;
    }

    private IEnumerator RegenerateHealthOverTime(float duration, float healthToRegenerate)
    {
        float elapsedTime = 0f;
        float initialHealth = currentHealth;
        float targetHealth = Mathf.Min(currentHealth + healthToRegenerate, maxHealth); 

        while (elapsedTime < duration) 
        {
            elapsedTime += Time.deltaTime;
            currentHealth = Mathf.Lerp(initialHealth, targetHealth, elapsedTime / duration);

            // Clamp health to ensure it doesn't exceed max health
            currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

            yield return null;
        }

        currentHealth = targetHealth;
    }
}
