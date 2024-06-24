using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIUpdater : MonoBehaviour
{
    //Getting Ammo Script and Display
    private GameObject ammoCountObject;
    private TextMeshProUGUI ammoCountText;
    private Shooting shootScript;
    //gameobject under player 
    [SerializeField] private GameObject shoot;

    //Getting Health script and Display

    //gameobject under player 

    [SerializeField] private GameObject Health;
    private GameObject healthBarObject;
    private Healthbar healthBarScript;
    private Health healthScript;
   
    void Awake()
    {
        shootScript = shoot.GetComponent<Shooting>();
        ammoCountObject = GameObject.Find("AmmoCount");
        ammoCountText = ammoCountObject.GetComponent<TextMeshProUGUI>();
        
        healthScript = Health.GetComponent<Health>();
        healthBarObject = GameObject.Find("HealthBar");
        healthBarScript = healthBarObject.GetComponent<Healthbar>();
    }

    // Update is called once per frame
    void Update()
    {
        ammoCountText.text = "Ammo: " + shootScript.ammoCount.ToString();
        healthBarScript.SetHealth(healthScript.health);
    }
}
