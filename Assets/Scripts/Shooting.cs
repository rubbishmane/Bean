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
    int reducingFactor = 2;
    
    

    private int damage = 10;

    public Camera cam;

    public ItemController ic;

    Gun currentGun;

    float shotDistance;
    int currentGunIndex;

    float maxDistance;

    float distanceFactor = 30f;

    bool canShoot;

    float fireRate;
    

    // Called when the game starts, before the start function.
    void Awake()
    {
        _avatar = transform.parent.GetComponent<Alteruna.Avatar>();
    }
    // Called after void Awake();
    void Start()
    {   
        if(ic != null)
        {
            currentGunIndex = ic.currentGunIndex;
            currentGun = ic.guns[currentGunIndex].GetComponent<Gun>();
            maxDistance = currentGun.initDistance;
        }
        else
        {
            Debug.Log("Item controller ic variable not found");
        }

        ammoCount = ic.AmmoCount[currentGunIndex];
        fireRate = currentGun.fireRate;
    }

    //Called every frame
    void Update()
    {   
        currentGun = ic.guns[currentGunIndex].GetComponent<Gun>();
        ammoCount = ic.AmmoCount[currentGunIndex];
        fireRate = currentGun.fireRate;
        //reqeuires avatar to be you or the function returns instantly.
        if(!_avatar.IsMe)
            return;

        if(Input.GetMouseButton(0) && ic.AmmoCount[currentGunIndex] >= 1 && canShoot)
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
        currentGunIndex = ic.currentGunIndex;
        maxDistance = currentGun.initDistance;
    }
    //Called when LMB is clicked
    
    void Shoot(int dmg)
    {
        if(!_avatar.IsMe)
        {
            return;
        }
        ic.AmmoCount[currentGunIndex] -= 1;
        Debug.Log("void Shoot");
        RaycastHit hit;
        //Shoots Raycast
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity))
        {
            shotDistance = hit.distance;
            canShoot = false;
            //Checks to see if hit has a player tag
              if(hit.transform.CompareTag("Player"))
            {
                //gets oppositions health component and take away health.
                GameObject _enemy = hit.collider.gameObject;
                Health _enemyHealth = _enemy.transform.parent.GetComponentInChildren<Health>();
                print(shotDistance);
                float DistanceReducedDamage(float distanceOfShot)
                {
                    Debug.Log("Init Dmg: " + currentGun.baseDamage);
                    
                    float finalDmg;
                    finalDmg = -(float)Math.Pow(reducingFactor, distanceOfShot - distanceFactor) + currentGun.baseDamage;
                    
                    if(finalDmg <=7)
                    {
                        //return zero if the bullets finalDmg is not greater then the minDamage of the bullet.
                        return 0f;
                    }
                    //Return a rounded value of finalDmg, to three significant figures
                    return (float)Math.Round(finalDmg, 3);
                }
                _enemyHealth.Damage(DistanceReducedDamage(shotDistance));
                Debug.Log("DMG after: " + DistanceReducedDamage(shotDistance));
            }
        }
    }

    void Reload()
    {  
        if(!_avatar.IsMe)
        {
            return;
        }
        ammoCount = ic.maxAmmoCount[currentGunIndex];
        ic.AmmoCount[currentGunIndex] = ic.maxAmmoCount[currentGunIndex];
    }

    IEnumerator shootTimer()
    {
        yield return new WaitForSeconds(1/fireRate);
        canShoot = true;
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

