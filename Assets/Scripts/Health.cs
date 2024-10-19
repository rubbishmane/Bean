using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna; 
using Alteruna.Trinity;
using UnityEngine.SceneManagement;
using System.Numerics;
//using Alteruna.Multiplayer;

public class Health : AttributesSync
{
    
    public float health;
    private float maxHealth = 100f;
    int count;
    private MeshRenderer capsuleRenderer;
   
    UnityEngine.Vector3 placeToSpawn;
    [SerializeField]GameManager manager;

    //private OnDeath onDeath;
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        health = maxHealth;
        //onDeath = transform.parent.GetComponent<OnDeath>();
    }
    //Broadcast function over network
    public void Damage(float damage)
    {   
        BroadcastRemoteMethod(nameof(Damage2), damage);
    }
    //Take damage 
    [SynchronizableMethod] 
    void Damage2 (float dmg)
    {
        if((health -= dmg) <= 0)
        {
            Die();
        }
        else
        {
            health -= dmg; 
        }
       
    }


    void Update()
    {
        if(manager == null)
        {
            manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }
        if(!Multiplayer.GetAvatar().IsMe)
        {
            return;
        }
       
        if(health <= 0f)
        {  
           Die();
        }
        
    }

    void Die()
    {
       
        manager.Respawn();
        
    }   

    void ReloadAllGuns()
    {

    }
}