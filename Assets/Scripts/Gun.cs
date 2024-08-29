using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UIElements;

public class Gun : MonoBehaviour
{
    public bool hasWeapon;
    public bool isEquipt;
    [Header("Time")]
    public float fireRate;// = {1.95f, 2.4f, 0.33f, 3f, 1f};

    public float reloadTime;// = {3f, 4f, 6f, 2.5f, 5f};
    [Header("Damage")]
    public float baseDamage; //{13f, 25f, 40f, 11f, 80f};

    public float initDistance;

    
    [Header("Ammo")]
    
    public int maxBulletDistance; //{20, 30, 12, 14, 150};
    
    public int maxAmmoCount;  
    [Header("Multipliers")]
    public float scopeMultiplier;//{0.8f, 0.65f, 0.9f, 0.7f, 0.3f};

    public float bloomMultiplier;

    public float recoilMultiplier;
    [Header("Particles")]
 
    public ParticleSystem particles;
    [Header("Crosshairs")]
    public float defaultFOV = 90f;
    public Sprite crossHair;
    public Vector2 chSize;

    

}

