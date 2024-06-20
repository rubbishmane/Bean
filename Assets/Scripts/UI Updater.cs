using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIUpdater : MonoBehaviour
{
    private GameObject ammoCountObject;
    public TextMeshProUGUI ammoCountText;
    private Shooting shootScript;
    [SerializeField] private GameObject shoot;
   
    void Awake()
    {
        shootScript = shoot.GetComponent<Shooting>();
        ammoCountObject = GameObject.Find("AmmoCount");
        ammoCountText = ammoCountObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
        ammoCountText.text = "Ammo: " + shootScript.ammoCount.ToString();
    }
}
