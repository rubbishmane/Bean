using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;
using UnityEngine.SceneManagement;
using TMPro;

public class StartNetowkr : AttributesSync

{
    [SerializeField] private TMP_InputField input;
    public void CreateAndJoing()
    {
        Multiplayer.CreateRoom("room", true, 1234, true, true, 2);
        SceneManager.LoadScene("Waiting");
    }

    void JoinRoom(){
        string roomName = input.text;
        print("Joining Room:" + roomName);
    }
}

