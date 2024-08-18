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
    public float damage;

    public float initDistance;

    
    [Header("Ammo")]
    public int magSize;
    [Header("Multipliers")]
    public float scopeMultiplier;

    public float bloomMultiplier;

    public float recoilMultiplier;
    [Header("Particles")]
 
    public ParticleSystem particles;
    [Header("Crosshairs")]
    public int defaultFOV = 90;
    public Sprite crossHair;
    public Vector2 chSize;

    void Awake()
    {
        Camera.main.fieldOfView = defaultFOV;
    }
}

