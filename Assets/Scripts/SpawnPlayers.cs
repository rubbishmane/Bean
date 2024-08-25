using System.Collections.Generic;
using UnityEngine;
using Alteruna;

public class SpawnPlayers : AttributesSync
{
    [SerializeField] public User terrorist, defence;
    [SerializeField] private int playerCount;

    public GameObject terroristSpawnObj;
    public GameObject defenseSpawnObj;

    private Vector3 terroristSpawn;
    private Vector3 defenseSpawn;
    bool isMax = false;

    List<User> Users = new List<User>();
    private User localUser;
    Room room;
    int v;
    bool shouldTry;
    public string theTerroristsName;

    void Start()
    {
        shouldTry = true;
        CheckPlayerCount();
        terroristSpawn = terroristSpawnObj.transform.position;
        defenseSpawn = defenseSpawnObj.transform.position;
    }

    void Update()
    {
        if (shouldTry)
        {
            TryConnect();
        }
        Users = Multiplayer.GetUsers();
    }

    void TryConnect()
    {
        if (isMax)
        {
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

    void CheckPlayerCount()
    {
        playerCount = 0;
        
        foreach (var user in Multiplayer.GetUsers())
        {
            playerCount++;
            print(playerCount);
            if (playerCount == 2)
            {
                isMax = true;
                Debug.Log("isMax = true");
                return;
            }
        }
    }

    
    void AssignRoles()
    {
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
        theTerroristsName = assignedTerroristName;

        // Check if this client is the terrorist
        if (theTerroristsName == Multiplayer.Me.Name)
        {
            Debug.Log("I am the terrorist");
            Multiplayer.SpawnAvatar(terroristSpawn);
        }
        else
        {
            Debug.Log("I am on defense");
            Multiplayer.SpawnAvatar(defenseSpawn);
        }
    }
}
