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

    public void ReDoBroadcast(int damage)
    {
        BroadcastRemoteMethod("TakeDamage", damage);
    }

    [SynchronizableMethod] 
    void TakeDamage (int dmg)
    {
        health -= (float)dmg; 
    }

    
}
