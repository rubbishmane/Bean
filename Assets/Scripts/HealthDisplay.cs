using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private TMP_Text healthText;

    void Update()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        healthText.text = "Health: " + health.GetCurrentHealth().ToString();
        
        
    }
}
