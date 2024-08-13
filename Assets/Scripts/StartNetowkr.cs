using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;
using UnityEngine.SceneManagement;
using TMPro;
using JetBrains.Annotations;

public class StartNetowkr : AttributesSync

{
    List<Alteruna.Room> room = new List<Alteruna.Room>();
    public void Create()
    {
        Multiplayer.CreateRoom("Room", false, 0, true);
        Multiplayer.LoadScene("Game");
    }

    public void Connect()
    {
        print("Join Attempted");
        Multiplayer.JoinFirstAvailable();
        Multiplayer.LoadScene("Game");
    }
}

