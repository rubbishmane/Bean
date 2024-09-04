using System.Collections;
using UnityEngine;
using Alteruna;

public class ShootingButBetter : MonoBehaviour
{
    Alteruna.Avatar _avatar;
    public Camera cam;
    ItemController ic;
    Gun currentGun;

    [HideInInspector] public int ammoCountToDisplay;
    int currentGunIndex;
    int reducingFactor = 2;

    float shotDistance;
    float maxDistance;
    float fireRate;

    bool canShoot;
    bool isShooting;
    bool isReloading;

    [HideInInspector] public int[] ammoCount = {7, 25, 5, 30, 1};

    void Awake()
    {
        _avatar = transform.parent.GetComponent<Alteruna.Avatar>();
        ic = transform.parent.GetComponentInChildren<ItemController>();
    }

    void Start()
    {
        if (!_avatar.IsMe)
            return;

        if (ic != null)
        {
            currentGunIndex = ic.currentGunIndex;
            currentGun = ic.guns[currentGunIndex].GetComponent<Gun>();
            maxDistance = currentGun.initDistance;
            AfterStart();
        }
        else
        {
            Debug.Log("Item controller ic variable not found");
        }
    }

    void AfterStart()
    {
        ammoCountToDisplay = ammoCount[currentGunIndex];
        fireRate = currentGun.fireRate;
        canShoot = true;
    }

    void Update()
    {
        if (!_avatar.IsMe)
            return;

        currentGunIndex = ic.currentGunIndex;
        currentGun = ic.guns[currentGunIndex].GetComponent<Gun>();
        ammoCountToDisplay = ammoCount[currentGunIndex];
        fireRate = currentGun.fireRate;
        maxDistance = currentGun.initDistance;

        // Check if the gun switch occurs during reloading, and cancel the reload
        if (isReloading && ic.currentGunIndex != currentGunIndex)
        {
            CancelReload();
        }

        if (ammoCount[currentGunIndex] >= 1)
        {
            canShoot = true;
        }

        if (Input.GetMouseButton(0) && canShoot && !isShooting)
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        Scope();
    }

    void Scope()
    {
        if (Input.GetMouseButtonDown(1))
        {
            cam.fieldOfView = Mathf.Lerp(currentGun.defaultFOV, currentGun.scopeMultiplier * currentGun.defaultFOV, 0.7f);
        }
        if (Input.GetMouseButtonUp(1))
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, currentGun.defaultFOV, 0.7f);
        }
    }

    void Shoot()
    {
        isShooting = true;
        if (!canShoot || ammoCount[currentGunIndex] < 1 || !_avatar.IsMe)
            return;

        RaycastHit hit;
        Debug.Log("Shoot void");

        StartCoroutine(ShootDelay());
        ammoCount[currentGunIndex] -= 1;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity))
        {
            Debug.Log("Raycast");
            shotDistance = hit.distance;
            canShoot = false;

            if (hit.transform.CompareTag("Player"))
            {
                Debug.Log("Compare Player");
                GameObject _enemy = hit.collider.gameObject;
                Health _enemyHealth = _enemy.transform.parent.GetComponentInChildren<Health>();

                float DistanceReducedDamage(float distanceOfShot)
                {
                    Debug.Log("Init Dmg: " + currentGun.baseDamage.ToString());
                    float finalDmg = -(Mathf.Pow(reducingFactor, distanceOfShot - currentGun.maxBulletDistance)) + currentGun.baseDamage;
                    return Mathf.Max(finalDmg, 0f); // Ensure final damage doesn't go below 0
                }

                _enemyHealth.Damage(DistanceReducedDamage(shotDistance));
                Debug.Log("DMG after: " + DistanceReducedDamage(shotDistance));
            }
        }
    }

    void Reload()
    {
        if (!_avatar.IsMe || isReloading)
            return;

        canShoot = false;
        StartCoroutine(ReloadDelay());
    }

    public void CancelReload()
    {
        // Stop the reload coroutine if it's running
        StopCoroutine("ReloadDelay");
        isReloading = false;
        canShoot = true;
        Debug.Log("Reload canceled due to weapon switch");
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(1 / currentGun.fireRate);
        canShoot = true;
        isShooting = false;
    }

    IEnumerator ReloadDelay()
    {
        isReloading = true;
        yield return new WaitForSeconds(currentGun.reloadTime);
        ammoCount[currentGunIndex] = currentGun.maxAmmoCount;
        canShoot = true;
        isReloading = false;
        Debug.Log("Reload complete");
    }
}
