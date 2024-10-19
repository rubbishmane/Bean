using System.Collections.Generic;
using UnityEngine;
using Alteruna;

public class BombSpawner : AttributesSync
{
    public GameObject bombPrefab;  // Prefab of the bomb to spawn

    // A list of lists to hold the possible bomb locations for each level
    public Transform[] bombLocationsPerLevel;

    void Start()
    {
        
    }
    public void doit()
    {
        InvokeRemoteMethod("SyncBombSpawn", UserId.AllInclusive);
    }
    // Method to be called across all clients to sync bomb spawn
    [SynchronizableMethod]
    public void SyncBombSpawn()
    {
        for(int i = 0; i < bombLocationsPerLevel.Length; i++)
        {
            Instantiate(bombPrefab, bombLocationsPerLevel[i]);
        }
        
    }
}
