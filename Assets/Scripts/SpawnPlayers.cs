using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;
using Alteruna.Trinity;
using Unity.VisualScripting.Antlr3.Runtime;

public class SpawnPlayers : AttributesSync
{
    // Start is called before the first frame update

    public Multiplayer multiplayer;
    
    [SynchronizableField][SerializeField] User whoIsTerrorist, whoIsDefence;
 
    private int playerCount;

    public GameObject terroristSpawnObj;
    public GameObject defenseSpawnObj;

    private Vector3 terroristSpawn;
    private Vector3 defenseSpawn;
    bool isMax;
    List<User> Users = new List<User>();
    Room room;

    
    
    void Awake()
    {
        terroristSpawn = terroristSpawnObj.transform.position;
        defenseSpawn = defenseSpawnObj.transform.position;
        playerCount = 0;
        isMax = false;
        Users = new List<User>();

    }
    void Update()
    {

        if(playerCount == 2){isMax = true;}
        if(isMax)
        {
            AssignRoles();
            
        }
        else
        {
            CheckPlayerCount();
        }
    }
    void CheckPlayerCount()
    {
        playerCount = 0;
        foreach (var user in multiplayer.GetUsers())
        {
            playerCount++;
        }
    }

    void AssignRoles()
    {   
        whoIsTerrorist = Users[Random.Range(0,1)];
        
        if(whoIsTerrorist != multiplayer.GetUser())
        {   
            whoIsDefence = multiplayer.GetUser();
        }
    }

    void SpawnPlayer()
    {
        if(whoIsDefence == multiplayer.GetUser())
        {
            multiplayer.SpawnAvatar(defenseSpawn);
        }
        else if(whoIsTerrorist == multiplayer.GetUser())
        {
            multiplayer.SpawnAvatar(terroristSpawn);
        }
        else
        {
            return;
            Debug.Log("Roles are not set");
        }
    }
}




