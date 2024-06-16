using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna; 
//using Alteruna.Multiplayer;

//Written Entirely by Matthew
public class Health : AttributesSync
{
    //private MultiplayerManager multiplayerManager;

    [SerializeField] private int maxHealth = 100;
    //SyncField makes the var synch with multiplayer
    [SerializeField] public int currentHealth;
    public Alteruna.Avatar avatar;

    // Start is called before the first frame update
    void Start()
    {      
        //multiplayerManager = FindObjectOfType<MultiplayerManager>();
        currentHealth = maxHealth;
        //ushort userIndex = multiplayerManager.GetUserIndex();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L)){TakeDamage();}
        if(Input.GetKeyDown(KeyCode.K)){Heal(10);}

    }
    public void ReDoBroadcast(int dmg){
        Debug.Log("This Worked");
        BroadcastRemoteMethod("TakeDamage");
    }
    [SynchronizableMethod]
    public void TakeDamage()
    {
        Debug.Log("Damage taken");
        if(!avatar.IsMe)
            return;

        currentHealth -=  10; 
        if (currentHealth <= 0) 
        {
            Debug.Log("Should Die");
            currentHealth = 0;  
            Die();
        }
    } 

    public void Heal(int amount)
    {
        
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    private void Die()
    {   
        Debug.Log("die void called");
        //indexUser = Alteruna.Avatar.Possessor.Index;
        //Alteruna.KickUser(indexUser);
        if(!avatar.IsMe)
        {
            return;
        }
        else
        {
            
            FindObjectOfType<Multiplayer>().CurrentRoom.Leave();
            Debug.Log("You have died tragically");
            Application.Quit();
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

}
