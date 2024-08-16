using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;
using Alteruna.Trinity;
using Unity.VisualScripting.Antlr3.Runtime;
using System;
public class Shooting : AttributesSync
{
  

    public  Alteruna.Avatar _avatar;

    public int ammoCount;
    private int maxAmmoCount = 10;
    

    private int damage = 10;

    public Camera cam;

    ItemController ic;

    float shotDistance;

    

    // Called when the game starts, before the start function.
    void Awake()
    {

        ic = GetComponent<ItemController>();
        _avatar = transform.parent.GetComponent<Alteruna.Avatar>();
    }
    // Called after void Awake();
    void Start()
    {   
        currentGunIndex = ic.currentGunIndex;
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

        
    }
    //Called when LMB is clicked
    
    void Shoot(int dmg)
    {
        if(!_avatar.IsMe)
        {
            return;
        }
        ammoCount -= 1;
        
        Debug.Log("void Shoot");
        RaycastHit hit;
        //Shoots Raycast
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity))
        {
            shotDistance = hit.distance;
            
            Debug.Log("Raycast shot");
            //Checks to see if hit has a player tag
            if(hit.transform.CompareTag("Player"))
            {
                Debug.Log("Compare Tag");

                //gets oppositions health component and take away health.
                GameObject _enemy = hit.collider.gameObject;
                Health _enemyHealth = _enemy.transform.parent.GetComponentInChildren<Health>();
                _enemyHealth.Damage(dmg);
            }
        }
    }

    void Reload()
    {  
        if(!_avatar.IsMe)
        {
            return;
        }
        ammoCount = maxAmmoCount;
    }
    int DistanceReducedDamage(int initDmg, float distance)
    {
        int finalDmg;
        finalDmg = Math.Pow(-20, distance - shotDistance) + ;
        return finalDmg;
    }


    


}

// public class Shotgun : Shooting
// {
//     Gun shotGun;
//     void Shoot(int initDamage)
//     {
//         RaycastHit shotGunHit;
//         if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out shotGunHit, Mathf.Infinity))
//         {
//             float hitDistance = shotGunHit.distance;
            
//         }
//     }

//     void Aim()
//     {
//         Camera.main.fieldOfView = shotGun.scopeMultiplier * shotGun.defaultFOV;
            
//     }


//}