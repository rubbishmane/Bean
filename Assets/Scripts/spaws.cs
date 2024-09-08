using System.Collections;
using System.Collections.Generic;
using System.Security;
using Alteruna;
using UnityEngine;

public class spaws : AttributesSync
{
    
    public GameObject[] spawns;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SpawnAPlayer()
    {
        
        int i = Random.Range(0, spawns.Length);
        Vector3 vec = spawns[i].transform.position;
        Multiplayer.SpawnAvatar(vec);
    }
}
