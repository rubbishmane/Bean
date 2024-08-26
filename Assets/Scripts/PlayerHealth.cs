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
        // Start the health regeneration process over 10seconds for 50% of max health.
        StartCoroutine(RegenerateHealthOverTime(10f, maxHealth * 0.5f));
    }


    private IEnumerator RegenerateHealthOverTime(float duration, float healthToRegenerate)
    {
        float elapsedTime = 0f;
        float initialHealth = currentHealth;
        float targetHealth = Mathf.Min(currentHealth + healthToRegenerate, maxHealth); 

        while (elapsedTime < duration) 
        {
            
            //elapsedTime / duration is a number between 0 and 1 and represents a percentage of the duration that has passed. As this value increases currentHealth moves closer to targetHealth
            elapsedTime += Time.deltaTime;
            currentHealth = Mathf.Lerp(initialHealth, targetHealth, elapsedTime / duration);
            

            // Clamps the health value to ensure it doesn't exceed max health.
            currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

            
            yield return null;
        }

       
        currentHealth = targetHealth;
    }
}
