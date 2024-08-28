using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenerateHealth : MonoBehaviour
{
    public Health healthScript; 
    public float maxHealth = 100f;
    

    void Awake()
    {
        healthScript = transform.parent.GetComponentInChildren<Health>();
    }


    public void ApplyHealthRegeneration()
    {
        // Start the health regeneration process over 10 seconds for 50% of max health
        StartCoroutine(RegenerateHealthOverTime(10f, maxHealth * 0.5f));
    }

    private IEnumerator RegenerateHealthOverTime(float duration, float healthToRegenerate)
    {
        float elapsedTime = 0f;
        float initialHealth = healthScript.health; 
        float targetHealth = Mathf.Min(initialHealth + healthToRegenerate, maxHealth); 
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
           
            healthScript.health = Mathf.Lerp(initialHealth, targetHealth, elapsedTime / duration);

            healthScript.health = Mathf.Clamp(healthScript.health, 0f, maxHealth);

            yield return null; 
        }

       
        healthScript.health = targetHealth;
    }
}
