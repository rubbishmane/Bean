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
    bool isTerrorist;
    bool isDefense;
    private int playerCount;
    bool isMax;
    List<User> Users = new List<User>();

    
    
    void Awake()
    {
        playerCount = 0;
        isMax = false;
        Users = new List<User>();
    }
    void Update()
    {

        if(playerCount == 2){isMax = true;}
        if(isMax)
        {
            StartGame();
            
        }
        else
        {
            CheckPlayerCount();
        }
    }
    void CheckPlayerCount()
    {
        playerCount = 0;
        foreach (var user in Multiplayer.GetUsers())
        {
            playerCount++;
        }
    }

    void StartGame()
    {
        Users[]
    }
}



