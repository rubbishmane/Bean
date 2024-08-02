using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;
using UnityEngine.SceneManagement;

public class StartNetowkr : AttributesSync
{
    public void CreateAndJoing()
    {
        Multiplayer.CreateRoom();
        SceneManager.LoadScene("Waiting");
    }
}
