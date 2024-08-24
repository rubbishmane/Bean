using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    
    public void ApplyHealthRegeneration()
    {
        // Start the health regeneration process over 10seconds for 50% of max health. I will change this in the futre if need be.
        StartCoroutine(RegenerateHealthOverTime(10f, maxHealth * 0.5f));
    }

// float duration means the total time which health generation should happen 
// float heathtoregen is is the amount of health to regen over the given duration 
    private IEnumerator RegenerateHealthOverTime(float duration, float healthToRegenerate)
    {
        float elapsedTime = 0f;
        float initialHealth = currentHealth;
        float targetHealth = Mathf.Min(currentHealth + healthToRegenerate, maxHealth); //Mathf.Min will return the smallest of two values, so either 100hp or whatever current health and heath to rengens equals this means it will never exced 100hp

        while (elapsedTime < duration) // elapsed time increases by 1 every second untill it is greater than the duration. 
        {
            // gradually changes the currenthealth from the inital health to target health over time.
            //elapsedTime / duration is a number between 0 and 1 and represents a percentage of the duration that has passed. As this value increases currentHealth moves closer to targetHealth
            elapsedTime += Time.deltaTime;
            currentHealth = Mathf.Lerp(initialHealth, targetHealth, elapsedTime / duration);
            

            // Optional: Clamp the health value to ensure it doesn't exceed max health.
            //basically restrict a value to a range that is defined by the minimum and maximum values???
            currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

            // this pauses the coroutine and resumes it on the next frame.
            yield return null;
        }

        // Ensure the health is exactly at the target value after regeneration completes.
        currentHealth = targetHealth;
    }
}
