using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;
using UnityEngine.SceneManagement;
using TMPro;

public class StartNetowkr : AttributesSync

{
    [SerializeField] private TMP_InputField input;
    public void Create()
    {
        Multiplayer.CreateRoom(Multiplayer.GetUser().Name + " 's room");
        Multiplayer.LoadScene("Game");
    }

    void JoinRoom(){
        Multiplayer.JoinFirstAvailable();
        Multiplayer.LoadScene("Game");
    }
}

