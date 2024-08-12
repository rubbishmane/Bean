using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;
using Alteruna.Trinity;
using Unity.VisualScripting.Antlr3.Runtime;

public class SpawnPlayers : CommunicationBridge
{
    // Start is called before the first frame update

    public Multiplayer multiplayer;
    
    [SerializeField] User whoIsTerrorist, whoIsDefence;
 
    [SerializeField]private int playerCount;

    public GameObject terroristSpawnObj;
    public GameObject defenseSpawnObj;

    private Vector3 terroristSpawn;
    private Vector3 defenseSpawn;
    bool isMax = false;
    List<User> Users = new List<User>();
    Room room;

    
    
    void Awake()
    {   
        terroristSpawn = terroristSpawnObj.transform.position;
        defenseSpawn = defenseSpawnObj.transform.position;
        playerCount = 0;

        

    }
    void Update()
    {

        if(playerCount == 2){isMax = true;}
        if(isMax)
        {
            //AssignRoles();
            print("User Count: 2");
            Multiplayer.SpawnAvatar(GameObject.Find("DefenseSpawn").transform.position);
            
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

    // void AssignRoles()
    // {   
    //     whoIsTerrorist = Users[Random.Range(0,1)];
        
    //     if(whoIsTerrorist != multiplayer.GetUser())
    //     {   
    //         whoIsDefence = multiplayer.GetUser();
    //     }
    //     print(whoIsDefence.Name);
    //     SpawnPlayer();
    // }

    // void SpawnPlayer()
    // {
    //     if(whoIsDefence == multiplayer.GetUser())
    //     {
    //         multiplayer.SpawnAvatar(defenseSpawn);
    //     }
    //     else if(whoIsTerrorist == multiplayer.GetUser())
    //     {
    //         multiplayer.SpawnAvatar(terroristSpawn);
    //     }
    //     else
    //     {
            
    //         Debug.Log("Roles are not set");
    //     }
    // }
}





