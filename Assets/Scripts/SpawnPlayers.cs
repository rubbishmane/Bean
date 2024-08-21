using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;
using Alteruna.Trinity;
using Unity.VisualScripting.Antlr3.Runtime;

public class SpawnPlayers : AttributesSync
{
    
    [SerializeField] User terrorist, defence;
 
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
    

    
    
    void Awake()
    {   
    
        playerCount = 0;
        

    }
    void Start()
    {
        terroristSpawn = terroristSpawnObj.transform.position;
        defenseSpawn = defenseSpawnObj.transform.position;
    }
    void Update()
    {

        if(playerCount == 2){isMax = true;}
        if(should)
        {TryConnect();}
        
    }

    void TryConnect()
    {
        if(isMax)
        {
            //AssignRoles();
            print("User Count: 2");
            Users = Multiplayer.GetUsers();
            //Multiplayer.SpawnAvatar(GameObject.Find("DefenseSpawn").transform.position);
            BroadcastRemoteMethod(nameof(AssignRoles), Random.Range(0,1));

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
        terrorist = Users[x];
        
        
        if(terrorist != Multiplayer.Me)
        {   
            defence = Multiplayer.Me;
        }
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        if(defence == Multiplayer.Me)
        {
            Multiplayer.SpawnAvatar(defenseSpawn);
        }
        else if(terrorist == Multiplayer.Me)
        {
            Multiplayer.SpawnAvatar(terroristSpawn);
        }
        else
        {
            
            Debug.Log("Roles are not set");
        }
    }
}





