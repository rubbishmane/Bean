using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;
using UnityEngine.SceneManagement;
using TMPro;
using JetBrains.Annotations;

public class StartNetowkr : AttributesSync

{
   public Multiplayer multiplayer;
    public void Create()
    {
        DontDestroyOnLoad(multiplayer.gameObject);
        Multiplayer.CreateRoom(Multiplayer.GetUser().Name + " 's room");
        Multiplayer.LoadScene("Game");
        
    }

    public void JoinRoom(){
        DontDestroyOnLoad(multiplayer.gameObject);
        Multiplayer.JoinFirstAvailable();
        Multiplayer.LoadScene("Game");
    }
}

