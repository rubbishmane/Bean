 using UnityEngine;
using Alteruna;
using System.Collections.Generic;

public class GameManager : AttributesSync
{
    public List<Transform> terroristSpawnPoints; // List of spawn points for terrorist in each room
    public List<Transform> defenseSpawnPoints;   // List of spawn points for defenders in each room
    private SpawnPlayers spawnScript;            // Reference to your existing SpawnPlayers script
    
    private Alteruna.Avatar myAvatar;
    public bool isTerrorist;
    private bool avatarAssigned = false;
    private bool avatarsSpawned = false;          // Track if avatars have been spawned for both players
    public bool bombPickedUp;
    [SerializeField] private int currentRoomIndex = 0;            // Start at room 0
    public GameObject sp;
    

    void Awake()
    {
        // Assuming SpawnPlayers script is on the same GameObject
        spawnScript = sp.GetComponent<SpawnPlayers>();
        if (spawnScript == null)
        {
            Debug.LogError("SpawnPlayers script not found on GameManager.");
            return;
        }

        // Ensure Multiplayer instance is available and access correctly
        if (Multiplayer.Instance == null)
        {
            Debug.LogError("Multiplayer instance not initialized.");
            return;
        }

        // Determine if this player is the terrorist
        isTerrorist = spawnScript.terrorist == Multiplayer.Instance.Me; // Use Multiplayer.Instance.Me
        Debug.Log("Awake");
    }
    void Start()
    {
        Debug.Log("Start");
        if (spawnScript != null)
        {
            Debug.Log(spawnScript.theTerroristsName);           
        }
        else
        {
            Debug.LogError("Spawn Script missing");
        }
            
    }
    void Update()
    {
        // Polling to find and assign the local player's avatar if it hasn't been assigned yet
        if (!avatarAssigned)
        {
            FindAndAssignLocalAvatar();
        }
        if(spawnScript.terrorist == null)
        {
            Debug.Log("Spawn Script Terrorist not assigned");
        }
    }
    // Method to find and assign the local player's avatar
    private void FindAndAssignLocalAvatar()
    {
        if (avatarAssigned)
            return;

        print("FindAndAssignLocalAvatar");
        // Loop through all avatars in the scene
        Alteruna.Avatar[] allAvatars = FindObjectsOfType<Alteruna.Avatar>();
        foreach (Alteruna.Avatar avatar in allAvatars)
        {
            print("ForEachLoop");
            if (avatar.IsMe)
            {
                myAvatar = avatar;
                avatarAssigned = true;
                
                
                break;
            }
            else
            {
                print("avatar not me");
            }
        }
    }

    // Move player to their initial spawn location
    

    // Method to handle bomb pickup
    public void BombPickedUp()
    {
        // Sync the bomb pickup status across all clients
        InvokeRemoteMethod("SyncBombPickup", UserId.AllInclusive);
    }

    [SynchronizableMethod]
    void SyncBombPickup()
    {
        bombPickedUp = true;
        Debug.Log("Bomb picked up by the terrorist.");
    }

    [SynchronizableMethod]
    public void SyncRoomTransition(int newRoomIndex)
    {
        newRoomIndex = currentRoomIndex;
        Debug.Log("Transitioning to room: " + newRoomIndex);

        // Move both players to their spawn points in the new room
        InvokeRemoteMethod("SpawnPlayersInRoom", UserId.AllInclusive, newRoomIndex);
    }

    // Move players to their spawn points when advancing to a new room
    [SynchronizableMethod]
    public void SpawnPlayersInRoom(int roomIndex)
    {
        if (myAvatar == null)
        {
            Debug.Log("Avatar null");
            
        }
        Debug.Log("SpawnPlayersInRoom");

        if (spawnScript.theTerroristsName == Multiplayer.Instance.Me.Name)
        {
            myAvatar.transform.position = terroristSpawnPoints[roomIndex].position;
            
            Debug.Log("move terrorst");
        }
        else
        {
            myAvatar.transform.position = defenseSpawnPoints[roomIndex].position;
        }
        
    }

    // Method to handle when the terrorist reaches the exit
    public void OnTerroristReachExit()
    {
        if (bombPickedUp)
        {
            currentRoomIndex++;
            // Sync room transition across all clients
            InvokeRemoteMethod("SyncRoomTransition", UserId.AllInclusive, currentRoomIndex);
        }
        else
        {
            Debug.Log("Terrorist must pick up the bomb first!");
        }
    }

    public void Respawn()
    {
        GameObject[] avatarOb = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < avatarOb.Length; i++)
        {
            Destroy(avatarOb[i]);
            Debug.Log(i + " was destroyed");
        }    
        spawnScript.RespawnSS();
    }
}
