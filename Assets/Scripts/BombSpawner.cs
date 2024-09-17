using System.Collections.Generic;
using UnityEngine;
using Alteruna;

public class BombSpawner : AttributesSync
{
    public GameObject bombPrefab;  // Prefab of the bomb to spawn

    // A list of lists to hold the possible bomb locations for each level
    public List<Transform[]> bombLocationsPerLevel = new List<Transform[]>();

    void Start()
    {
        // If this client is the host, decide the bomb locations
        if (Multiplayer.Instance.Me.IsHost)
        {
            for (int levelIndex = 0; levelIndex < bombLocationsPerLevel.Count; levelIndex++)
            {
                // Randomly choose a bomb location and synchronize it across all clients
                int randomLocationIndex = Random.Range(0, bombLocationsPerLevel[levelIndex].Length);
                InvokeRemoteMethod("SyncBombSpawn", UserId.AllInclusive, levelIndex, randomLocationIndex);
            }
        }
    }

    // Method to be called across all clients to sync bomb spawn
    [SynchronizableMethod]
    void SyncBombSpawn(int levelIndex, int locationIndex)
    {
        // Get the array of bomb locations for the level
        Transform[] bombLocations = bombLocationsPerLevel[levelIndex];

        // Instantiate the bomb prefab at the synchronized location
        Instantiate(bombPrefab, bombLocations[locationIndex].position, Quaternion.identity);

        Debug.Log($"Bomb spawned on level {levelIndex + 1} at location {locationIndex + 1}");
    }
}
