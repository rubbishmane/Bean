using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;
using Alteruna.Trinity;
using TMPro;

public class Shooting : AttributesSync
{
  

    public  Alteruna.Avatar _avatar;

    [SerializeField] private int ammoCount;
    private int maxAmmoCount = 10;
    public TextMeshProUGUI ammoText;

    private int damage = 10;

    // Called when the game starts, before the start function.
    void Awake()
    {
        _avatar = transform.parent.GetComponent<Alteruna.Avatar>();
    }
    // Called after void Awake();
    void Start()
    {   
        ammoCount = maxAmmoCount;
    }

    //Called every frame
    void Update()
    {   
        //reqeuires avatar to be you or the function exits.
        if(!_avatar.IsMe)
            return;

        if(Input.GetMouseButtonDown(0) && ammoCount >= 1 )
        {
            Shoot(damage);
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        ammoText.text = ammoCount.ToString();
    }
    //Called when LMB is clicked
    void Shoot(int dmg)
    {
        ammoCount -= 1;
        
        Debug.Log("void Shoot");
        RaycastHit hit;
        //Shoots Raycast
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            Debug.Log("Raycast shot");
            //Checks to see if hit has a player tag
            if(hit.transform.CompareTag("Player"))
            {
                Debug.Log("Compare Tag");

                //gets oppositions health component and take away health.
                GameObject _enemy = hit.collider.gameObject;
                Health _enemyHealth = _enemy.transform.parent.GetComponentInChildren<Health>();
                _enemyHealth.ReDoBroadcast(dmg);
            }
        }
    }

    void Reload()
    {   

        ammoCount = maxAmmoCount;
    }


}
