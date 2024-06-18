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
    public void ReDoBroadcast(int damage)
    {
        BroadcastRemoteMethod("Damage", damage);
    }
    //Take damage 
    [SynchronizableMethod] 
    void Damage (int dmg)
    {
        health -= (float)dmg; 
    }


}
