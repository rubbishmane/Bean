using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;
using Alteruna.Trinity;
using Unity.VisualScripting.Antlr3.Runtime;
using JetBrains.Annotations;

public class SpawnPlayers : AttributesSync
{
    
    [SerializeField] public User terrorist, defence;
 
    [SerializeField]private int playerCount;

    public GameObject terroristSpawnObj;
    public GameObject defenseSpawnObj;

    private Vector3 terroristSpawn;
    private Vector3 defenseSpawn;
    bool isMax = false;
    bool should = true;
    List<User> Users = new List<User>();
    private User localUser;
    Room room;
    int v;

    public string theTerroristsName;
    

    
    
    void Awake()
    {   
        isMax = false;
        playerCount = 0;
        
    
    }
    void Start()
    {
        CheckPlayerCount();
        terroristSpawn = terroristSpawnObj.transform.position;
        defenseSpawn = defenseSpawnObj.transform.position;
    }
    void Update()
    {
        CheckPlayerCount();
        if(playerCount == 2){isMax = true;}
        if(should)
        {TryConnect();}
        
    }

    void TryConnect()
    {
        if(isMax)
        {
            if(Multiplayer.GetUser().IsHost)
            {
                v = Random.Range(0,2);
                print("random int :" + v);
                terrorist = Users[v];
                theTerroristsName = Users[v].Name;
                BroadcastRemoteMethod(nameof(AssignRoles));
            }
            //AssignRoles();
            print("User Count: 2");
            Users = Multiplayer.GetUsers();
            //Multiplayer.SpawnAvatar(GameObject.Find("DefenseSpawn").transform.position);
            

            should = false;
            
        }
        else
        {
            CheckPlayerCount();
            print("User Count: 1");
        }
    }
    
    void CheckPlayerCount()
    {
        playerCount = 0;
        foreach (var user in Multiplayer.GetUsers())
        { 
            playerCount++;
            print(playerCount);
        }
    }
    [SynchronizableMethod]
    void AssignRoles(int x)
    {
        Users = Multiplayer.GetUsers();  // Ensure the Users list is populated
        Debug.Log("Number of users: " + Users.Count);

                    
        Debug.Log(terrorist.Name + " is Terrorist");

        if (theTerroristsName == Multiplayer.Me.Name)
        {
            Debug.Log("I am the terrorist");
        }
        else
        {
                
            Debug.Log(defence.Name + " is Defence");
        }

        SpawnPlayer();
        
        
        
        Debug.LogError("Invalid index for assigning roles. Index: " + x + ", Users Count: " + Users.Count);
        
    }


    void SpawnPlayer()
    {
        if(theTerroristsName != Multiplayer.Me.Name)
        {
            Multiplayer.SpawnAvatar(defenseSpawn);
        }
        else if(theTerroristsName == Multiplayer.Me.Name)
        {
            Multiplayer.SpawnAvatar(terroristSpawn);
        }
        else
        {
            
            Debug.Log("Roles are not set");
        }
    }
}





