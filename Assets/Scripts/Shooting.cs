using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    class Pistol
    {
        int dmgAmount = 15;
        //bla blah
    }
    class Shotty
    {
        int DmgAmount = 60;
    }

    public List<GameObject> Items;
    public GameObject origin;
    private Vector3 shootingOrigin;
    private ItemController controlScript;

    void Awake()
    {
        shootingOrigin = origin.transform.position;
        LayerMask.GetMask("Penetrateble");
        controlScript = GetComponent<ItemController>();
    }
    void Update()
    {
        //currentItem = ItemConroller.equipt;
        if(Input.GetMouseButtonDown(0))
        {
            Shoot("ppop", 1);
        }
    }

    void Shoot(string Item, int dmg)
    {
        RaycastHit hit;
        if(Physics.Raycast(shootingOrigin, Vector3.forward, out hit, Mathf.Infinity))
        {
            print("shot something");
        }
    }
}
