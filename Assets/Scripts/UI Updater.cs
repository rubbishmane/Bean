using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIUpdater : MonoBehaviour
{
    private GameObject ammoCountObject;
    public TextMeshProUGUI ammoCount;
    private Health health;
   
    void Start()
    {
        ammoCountObject = GameObject.Find("ammoCount");
        ammoCount = ammoCountObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        ammoCount.text = health.Damage(10f);
    }
}
