using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna; 
//using Alteruna.Multiplayer;

public class Health : AttributesSync
{



    
    public float health;
    private float maxHealth = 100f;

    private OnDeath onDeath;
  

    void Start()
    {
        health = maxHealth;
        onDeath = transform.parent.GetComponent<OnDeath>();
    }
    //Broadcast function over network
    public void Damage(int damage)
    {   
        BroadcastRemoteMethod(nameof(Damage2), damage);
    }
    //Take damage 
    [SynchronizableMethod] 
    void Damage2 (int dmg)
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
            Application.Quit();
        }
        onDeath.Death();
        

        
    }

}
