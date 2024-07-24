using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Gun : MonoBehaviour
{
    public bool hasWeapon;
    public bool isEquipt;
    public float fireRate;

    public float reloadTime;

    public float damage;

    public int magSize;

    public float scopeMultiplier;

    public float bloomMultiplier;

    public float recoilMultiplier;

 
    public ParticleSystem particles;
}
