using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Alteruna;
using UnityEditor.Experimental.GraphView;

public class ShootingButBetter : MonoBehaviour
{

    Alteruna.Avatar _avatar;

    Camera cam;

    ItemController ic;
    Gun currentGun;

    public int ammoCountToDisplay;
    public int damage;
    int currentGunIndex;
    int reducingFactor = 2;

    float shotDistance;
    float maxDistance;
    float distanceFactor;
    float fireRate;

    bool canShoot;

    void Awake()
    {
        _avatar = transform.parent.GetComponent<Alteruna.Avatar>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if(!_avatar.IsMe)
            return;
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

        ammoCountToDisplay = currentGun.ammoCount[currentGunIndex];
        fireRate = currentGun.fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if(!_avatar.IsMe)
            return;

        currentGun = ic.guns[currentGunIndex].GetComponent<Gun>();
        ammoCountToDisplay = currentGun.ammoCount[currentGunIndex];
        fireRate = currentGun.fireRate;
        
        if(currentGun.ammoCount[currentGunIndex] >= 1)
        {
            canShoot = false;
        }

        if(Input.GetMouseButton(0))
        {
            if(canShoot)
            {
                Shoot();
            }

            //if you cant shoot play a empty clip sound effect
        }

        if(Input.GetMouseButton(1) && currentGun != null)
        {
            Scope();
        }
        else
        {
            cam.fieldOfView = currentGun.defaultFOV; 
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

    void Scope()
    {
        while(Input.GetMouseButton(1))
        {
            cam.fieldOfView = currentGun.scopeMultiplier[currentGunIndex] * currentGun.defaultFOV;
        }
        
    }

    void Shoot()
    {

        if(!_avatar.IsMe)
        {
            return;
        }

        RaycastHit hit;

        
        StartCoroutine("ShootDelay");
        currentGun.ammoCount[currentGunIndex]--;
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

        canShoot = false;
        StartCoroutine("ReloadDelay");
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(1/currentGun.fireRate);
        canShoot = true;
    }

    IEnumerator ReloadDelay()
    {
        yield return new WaitForSeconds(currentGun.reloadTime);
        currentGun.ammoCount[currentGunIndex] = currentGun.maxAmmoCount[currentGunIndex];
        canShoot = true;
        
    }
}
