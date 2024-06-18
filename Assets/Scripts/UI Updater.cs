using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIUpdater : MonoBehaviour
{
    private GameObject ammoCountObject;
    public TextMeshProUGUI ammoCount;
   
    void Start()
    {
        ammoCountObject = GameObject.Find("ammoCount");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
