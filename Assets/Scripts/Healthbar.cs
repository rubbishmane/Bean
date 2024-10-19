using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    Health healthScript; 
    // void Awake()
    // {
    //     healthScript = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Health>();
    // }
    // void Start()
    // {
    //     SetMaxHealth(healthScript.health);
    // }

    // public void SetMaxHealth(float health)
    // {
    //     slider.maxValue = health;
    //     slider.value = health;
    // }

    // public void SetHealth(float health)
    // {
    //     slider.value = health;
    // }

    // void Update()
    // {
    //     // Update the health bar based on the current health value in the Health script
    //     SetHealth(healthScript.health);
    // }
}
