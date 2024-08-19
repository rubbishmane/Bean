using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna; 
using UnityEngine.SceneManagement;
//using Alteruna.Multiplayer;

public class Health : AttributesSync
{
    
    public float health;
    private float maxHealth = 100f;
    int count;

    //private OnDeath onDeath;
    void Start()
    {
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
            //Die();
            Application.Quit();
        }
    }

    void Die()
    {
        Multiplayer.LoadScene("Menu");
            //Destroy(transform.parent.gameObject);
    }
}