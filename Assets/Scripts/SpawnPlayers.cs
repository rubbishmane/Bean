using System.Collections.Generic;
using UnityEngine;
using Alteruna;
using Unity.VisualScripting;

public class SpawnPlayers : AttributesSync
{
    [HideInInspector] public User terrorist, defence;
    public int playerCount;
    Room currentRoom;
    public RoomManager startNetwork;
   
    public GameManager manager;
    
    bool isMax = false;

    List<User> Users = new List<User>();
    private User localUser;
    Room room;
    int v;
    bool shouldTry;
    [HideInInspector]public string theTerroristsName;

    void Awake()
    {
        startNetwork = GameObject.Find("Manage").GetComponent<RoomManager>();
        currentRoom = Multiplayer.Instance.CurrentRoom;
        shouldTry = true;
        CheckPlayerCount();

        Debug.Log("SpawnPlayers Awake");
        print("test");
    }
    void Start()
    {
        Debug.Log("SpawnPlayers Start");
        if(manager == null)
        {
            Debug.Log("manager null");
        }
        print("test2");
    }

    void Update()
    {
        currentRoom = Multiplayer.Instance.CurrentRoom;
        if (shouldTry)
        {
            TryConnect();
            print("trying to connect");
        }
        Users = Multiplayer.GetUsers();
        if(manager == null)
        {
            Debug.Log("manager null");
           
        }
        
    }

    void TryConnect()
    {
        if (isMax)
        {
           manager.gameObject.SetActive(true);;
            shouldTry = false;
            
            print("User Count: " + Users.Count);
            if (Multiplayer.Me.IsHost)
            {
                AssignRoles();
            }
        }
        else
        {
            CheckPlayerCount();
            print("Not enough users");
        }
    }
    // Check how many players are currently in the room
    void CheckPlayerCount()
    {
        if (Multiplayer.Instance == null)
        {
            Debug.LogError("Multiplayer instance not initialized.");
            
        }

        var users = Multiplayer.Instance.GetUsers();

        if(users == null)
        {
            Debug.LogError("No users found, Multiplayer.GetUsers() returned null.");
            
        }
        playerCount = 0;
        
        foreach (var user in users)
        {
            playerCount++;
            print(playerCount);
            if (playerCount == 2)
            {
                isMax = true;
                Debug.Log("isMax = true");
                manager.transform.gameObject.SetActive(true);
                
            }
        }


    }

    public void RespawnSS()
    {
        Debug.Log("Respawn");
        InvokeRemoteMethod("RespawnSync", UserId.AllInclusive);
    }
    [SynchronizableMethod]
    void RespawnSync()
    {
        currentRoom = Multiplayer.Instance.CurrentRoom;
        currentRoom.Leave();
        // if(theTerroristsName == Multiplayer.Me.Name)
        // {
        //     Debug.Log("spawned host");
        //     Multiplayer.SpawnAvatar(manager.terroristSpawnPoints[0]);

        // }
        // else
        // {
        //     Debug.Log("Spawned client");
        //     Multiplayer.SpawnAvatar(manager.defenseSpawnPoints[0]);
        // }
        startNetwork.RespawnFunction ();
    }

    
    
    public void AssignRoles()
    {
        
        Debug.Log("assign roles");
        // This code is executed on the host to assign roles
        v = Random.Range(0, 2);
        print("random int :" + v);
        terrorist = Users[v];
        theTerroristsName = Users[v].Name;
        
        // Sync the role assignment with other clients
        InvokeRemoteMethod("SyncRoles", UserId.AllInclusive, theTerroristsName);
    }

    [SynchronizableMethod]
    void SyncRoles(string assignedTerroristName)
    {
        Debug.Log("SyncRoles");
        theTerroristsName = assignedTerroristName;

        // Check if this client is the terrorist
        if (theTerroristsName == Multiplayer.Me.Name)
        {
            Debug.Log("I am the terrorist");
            
            Multiplayer.SpawnAvatar(manager.terroristSpawnPoints[0]);
            
            
        }
        else
        {
            Debug.Log("I am on defense");
            Multiplayer.SpawnAvatar(manager.defenseSpawnPoints[0]);
        }
    }
    // void RespawnPlayer()
    // {
    //     Invoker
    // }
    // [SynchronizableMethod]
    // void RespawnPlayerSync(int index)
    // {
    //     v = Random.Range(0, 2);
    //     if(v == 1)
    //     {
    //         Multiplayer.SpawnAvatar(manager.defenseSpawnPoints[index]);
    //     }
    //     else
    //     {
    //         Multiplayer.SpawnAvatar(manager.terroristSpawnPoints[index]);
    //     }

        
    // }


}




        