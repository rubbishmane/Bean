using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Alteruna;



public class UIUpdater : MonoBehaviour
{


    public  Alteruna.Avatar _avatar;

    //Getting Ammo Script and Display
    private GameObject ammoCountObject;
   
    private TextMeshProUGUI ammoCountText;
    private TextMeshProUGUI healthText;
    private Shooting shootScript;
    //gameobject under player 
    [SerializeField] private GameObject shoot;

    //Getting Health script and Display

    //gameobject under player 

    [SerializeField] private GameObject Health;
    [SerializeField]private GameObject healthBarObject;
    private Healthbar healthBarScript;
    private Health healthScript;

    private int SelfLayer; 
    void Awake()
    {
       
        
        
        _avatar = transform.parent.GetComponent<Alteruna.Avatar>();
        
        shootScript = shoot.GetComponent<Shooting>();
        ammoCountObject = GameObject.Find("AmmoCount");
        ammoCountText = ammoCountObject.GetComponent<TextMeshProUGUI>();
        
        healthScript = Health.GetComponent<Health>();
        healthBarObject = GameObject.Find("HealthBar");
        healthText = healthBarObject.GetComponent<TextMeshProUGUI>();
        //healthBarScript = healthBarObject.GetComponent<Healthbar>();
    }

    void Start()
    {
         if(_avatar.IsMe)
        {
            //sets layer
            gameObject.layer = SelfLayer; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!_avatar.IsMe)
            return;
        ammoCountText.text = "Ammo: " + shootScript.ammoCount.ToString();
        healthText.text = "Health: " + healthScript.health.ToString();
        //healthBarScript.SetHealth(healthScript.health);
    }
}
