using System;
using System.Collections;
using System.Collections.Generic;
using Alteruna;
using UnityEditor;
using UnityEngine;

public class GameManager : AttributesSync
{
    SpawnPlayers spawningScript;
    Health health;

    int currentRoom;
    int bombCount;
    User winner;
    
    Transform[] bombPosititons;
    [SerializeField] GameObject bombPrefab;
   
    
    // Start is called before the first frame update
    void Start()
    {
        spawningScript = GameObject.Find("Spawning Manager").GetComponent<SpawnPlayers>();

        SetBombLocs();
    }
    void SetBombLocs()
    {
        for(int i = 0;i < bombPosititons.Length;i++)
        {
            Instantiate(bombPrefab, bombPosititons[i]);
        }
        
    }

    void SpawnBombs(Transform where)
    {
        Instantiate(bombPrefab, where);
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

