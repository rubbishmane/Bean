using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;

public class Shooting : AttributesSync
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

    //public List<GameObject> Items;
  
    private ItemController controlScript;
    private Alteruna.Avatar _avatar;
    [SerializeField] private LayerMask playerLayerMask;
    [SerializeField] private int playerSelfLayer;

    void Awake()
    {
        _avatar = transform.parent.GetComponent<Alteruna.Avatar>();
    }
    void Start()
    {   
        if(_avatar.IsMe)
            _avatar.gameObject.layer = playerSelfLayer;
        //controlScript = GetComponent<ItemController>();
    }
    void Update()
    {
        if(!_avatar.IsMe)
            return;
        //currentItem = ItemConroller.equipt;
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("MouseDown");
            Shoot("ppop", 1);
        }
    }

    void Shoot(string Item, int dmg)
    {
        Debug.Log("void Shoot");
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            Debug.Log("Raycast shot");
            if(hit.transform.CompareTag("Player"))
            {
                Debug.Log("Compare Tag");
                GameObject _enemy = hit.collider.gameObject;
                Health _enemyHealth = _enemy.transform.parent.GetComponentInChildren<Health>();
                _enemyHealth.ReDoBroadcast();
            }
        }
    }
}
