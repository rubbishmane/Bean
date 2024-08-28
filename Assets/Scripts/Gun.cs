using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Gun : MonoBehaviour
{
    public bool hasWeapon;
    public bool isEquipt;
    [Header("Time")]
    public float fireRate;

    public float reloadTime;
    [Header("Damage")]
    public float baseDamage;

    public float initDistance;

    
    [Header("Ammo")]
    
    int[] maxBulletDistance = {20, 30, 12, 14, 150};
    public int[] ammoCount = {7, 25, 5, 30, 1};
    [HideInInspector] public int[] maxAmmoCount;
    [Header("Multipliers")]
    public float[] scopeMultiplier = {0.8f, 0.65f, 0.9f, 0.7f, 0.3f};

    public float bloomMultiplier;

    public float recoilMultiplier;
    [Header("Particles")]
 
    public ParticleSystem particles;
    [Header("Crosshairs")]
    public float defaultFOV = 90f;
    public Sprite crossHair;
    public Vector2 chSize;

    

}

