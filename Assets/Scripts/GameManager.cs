using System;
using System.Collections;
using System.Collections.Generic;
using Alteruna;
using UnityEngine;

public class GameManager : AttributesSync
{
    SpawnPlayers spawningScript;
    Health health;

    int currentRoom;
    int bombCount;
    User winner;
    
    // Start is called before the first frame update
    void Start()
    {
        spawningScript = GameObject.Find("Spawning Manager").GetComponent<SpawnPlayers>();
    }

    
    void Update()
    {
        
    }
    void PickedUpABomb()
    {
        bombCount++;
    }

    void SwitchRoms()
    {

    }

    void EndGame()
    {
       if(winner == spawningScript.terrorist)
       {
            Multiplayer.LoadScene("Terrorist Wins");
       }
       else if(winner == spawningScript.defence)
       {
            Multiplayer.LoadScene("Defense Wins");
       }
       
    }
}

