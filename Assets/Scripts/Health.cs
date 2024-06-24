using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna; 
//using Alteruna.Multiplayer;

public class Health : AttributesSync
{
    public float health;
    private float maxHealth = 100f;
    void Start()
    {
        health = maxHealth;
    }
    //Broadcast function over network
    public void Damage(int damage)
    {
        BroadcastRemoteMethod("Damage_", damage);
    }
    //Take damage 
    [SynchronizableMethod] 
    void Damage_ (float dmg)
    {
        health -= dmg; 
    }


}
