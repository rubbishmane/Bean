using UnityEngine;

public class DamageSimulator : MonoBehaviour
{
    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            // Apply the health boost after 2 seconds
            Invoke("TriggerHealthBoost", 2f);

            // Simulate taking damage 5 seconds into the game, while boost is active
            Invoke("SimulateDamage", 7f);
        }
        else
        {
            Debug.LogError("PlayerHealth component not found on the GameObject!");
        }
    }

    void TriggerHealthBoost()
    {
        playerHealth.ApplyHealthBoost();
    }

    void SimulateDamage()
    {
        playerHealth.TakeDamage(100f); // Simulating taking 100 damage points
    }
}
