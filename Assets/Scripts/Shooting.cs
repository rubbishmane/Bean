using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;
using Alteruna.Trinity;
using Unity.VisualScripting.Antlr3.Runtime;
using System;
using Unity.VisualScripting;
public class Shooting : AttributesSync
{
  

    public  Alteruna.Avatar _avatar;

    public int ammoCount;
    private int maxAmmoCount = 10;
    

    private int damage = 10;

    public Camera cam;

    ItemController ic;

    Gun currentGun;

    float shotDistance;
    int currentGunIndex;

    float maxDistance;

    

    // Called when the game starts, before the start function.
    void Awake()
    {

        ic = transform.parent.GetComponent<ItemController>();
        _avatar = transform.parent.GetComponent<Alteruna.Avatar>();
    }
    // Called after void Awake();
    void Start()
    {   
        if(ic != null)
        {
            
        }
        currentGun = ic.guns[currentGunIndex].GetComponent<Gun>();
        ammoCount = maxAmmoCount;
        float maxDistance = currentGun.initDistance;
    }

    //Called every frame
    void Update()
    {   
        currentGun = ic.guns[currentGunIndex].GetComponent<Gun>();
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

    void LateUpdate()
    {
        print("ThisWorkes");
        currentGunIndex = ic.currentGunIndex;
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
                print(shotDistance);
                float DistanceReducedDamage(float initDmg, float distanceOfShot)
                {
                    float finalDmg;
                    finalDmg = (float)Math.Pow(-20,    - distanceOfShot) + currentGun.damage;
                    return finalDmg ;
                }

                _enemyHealth.Damage(DistanceReducedDamage(currentGun.GetComponent<Gun>().damage, shotDistance));
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

    //Params: intial damage the gun does before distance reducer, distance of shot
   

    


}

// public class Shotgun : Shooting
// {
//     Gun shotGun;
//     void Shoot(int initDamage)XZ
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