using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna; 
//using Alteruna.Multiplayer;

public class Health : AttributesSync
{


    public  Alteruna.Avatar _avatar;
    
    public float health;
    private float maxHealth = 100f;
  

    void Start()
    {
        _avatar = transform.parent.GetComponent<Alteruna.Avatar>();
        health = maxHealth;
    }
    //Broadcast function over network
    public void Damage(int damage)
    {   
        if(!_avatar.IsMe)
        {
            return;
        }
        BroadcastRemoteMethod("Damage_", damage);
    }
    //Take damage 
    [SynchronizableMethod] 
    void Damage2 (float dmg)
    {
        if(!_avatar.IsMe)
        {
            return;
        }
        health -= dmg; 
    }

    void Update()
    {

        if(!_avatar.IsMe)
        {
            return;
        }
        if(health <= 0f)
        {
            Application.Quit();
        }
    }

}
