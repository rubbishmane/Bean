using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private Text healthText;

    void Update()
    {
        healthText.text = "Health: " + health.GetCurrentHealth().ToString();
    }
}
