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
        terroristSpawn = terroristSpawnObj.transform.position;
        defenseSpawn = defenseSpawnObj.transform.position;
        playerCount = 0;
        
        multiplayer = GameObject.Find("Multiplayer Manager").GetComponent<Multiplayer>();
        

    }
    void Start()
    {
        localUser = multiplayer.Me;
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
            Users.Add(localUser);
            //Multiplayer.SpawnAvatar(GameObject.Find("DefenseSpawn").transform.position);
            AssignRoles();

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

    void AssignRoles()
    {   
        terrorist = Users[Random.Range(0,1)];
        
        
        if(terrorist != multiplayer.GetUser())
        {   
            defence = multiplayer.GetUser();
        }
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        if(defence == multiplayer.GetUser())
        {
            multiplayer.SpawnAvatar(defenseSpawn);
        }
        else if(terrorist == multiplayer.GetUser())
        {
            multiplayer.SpawnAvatar(terroristSpawn);
        }
        else
        {
            
            Debug.Log("Roles are not set");
        }
    }
}





