using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna; 
using Alteruna.Trinity;
using UnityEngine.SceneManagement;
//using Alteruna.Multiplayer;

public class Health : AttributesSync
{
    spaws spawn;
    public float health;
    private float maxHealth = 100f;
    int count;
    private MeshRenderer capsuleRenderer;

    //private OnDeath onDeath;
    void Start()
    {
        spawn = GameObject.Find("Spawns").GetComponent<spaws>();
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
        health -= dmg; 
    }


    void Update()
    {
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
        capsuleRenderer.enabled = false;
        health = maxHealth;
        ReloadAllGuns();

        
    }   

    void ReloadAllGuns()
    {

    }
}