using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float fireRate;

    public float reloadTime;

    public float damage;

    public int magSize;

    public float scopeMultiplier;

    public float bloomMultiplier;

    public float recoilMultiplier;

    public GameObject scopeObject;
    public GameObject crosshairObject;
    public GameObject particles;
}
