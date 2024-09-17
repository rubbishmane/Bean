using UnityEngine;
using Alteruna;

public class GameManager : AttributesSync
{
    public SpawnPlayers spawnScript;  // Reference to the SpawnPlayers script
    public Transform[] terroristSpawnPoints;  // Spawn points for terrorist in each room
    public Transform[] defenseSpawnPoints;    // Spawn points for defense in each room

    private int currentRoomIndex = 0;         // Track the current room
    private bool bombPickedUp = false;

    void Start()
    {
        // Initial spawn of players in the first room
        SpawnPlayersInRoom(0);
    }

    // Method to spawn players at their respective spawn points in a given room
    void SpawnPlayersInRoom(int roomIndex)
    {
        if (IsTerrorist())
        {
            MovePlayerToPosition(terroristSpawnPoints[roomIndex].position);
        }
        else
        {
            MovePlayerToPosition(defenseSpawnPoints[roomIndex].position);
        }
    }

    // Move the local player's avatar to a given position
    void MovePlayerToPosition(Vector3 newPosition)
    {
        Alteruna.Avatar playerAvatar = GetComponent<Alteruna.Avatar>();

        if (playerAvatar.IsMe)  // Ensure that the local player controls this avatar
        {
            playerAvatar.transform.position = newPosition;
        }
    }

    // Method to check if the local player is the terrorist
    public bool IsTerrorist()
    {
        // The terrorist is determined from the SpawnPlayers script
        if (spawnScript.terrorist == Multiplayer.Me)
        {
            return true;  // The local player is the terrorist
        }
        else
        {
            return false; // The local player is not the terrorist
        }
    }

    // Called when the terrorist reaches the exit pad and players should move to the next room
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

    // Synchronize room transition across all clients
    [SynchronizableMethod]
    void SyncRoomTransition(int newRoomIndex)
    {
        currentRoomIndex = newRoomIndex;
        Debug.Log("Transitioning to room: " + newRoomIndex);

        // Move both players to their spawn points in the new room
        SpawnPlayersInRoom(newRoomIndex);
    }

    // Method to call when the bomb is picked up
    public void BombPickedUp()
    {
        bombPickedUp = true;
        Debug.Log("Bomb picked up by the terrorist.");

        // Sync the bomb pickup status across all clients
        InvokeRemoteMethod("SyncBombPickup", UserId.AllInclusive);
    }

    [SynchronizableMethod]
    void SyncBombPickup()
    {
        bombPickedUp = true;
    }
}
