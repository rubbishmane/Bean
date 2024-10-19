using UnityEngine;
using Alteruna;
using System.Collections.Generic;
using Unity.VisualScripting;
using System;

public class RoomManager : AttributesSync
{
    List<Alteruna.Room> rooms = new List<Alteruna.Room>(); // List of rooms

    // Create a new room
    public void Create()
    {
        if (Multiplayer.Instance != null)
        {
            Multiplayer.Instance.CreateRoom("Room", false, 0, true, true, 2); // Use Multiplayer.Instance
            Multiplayer.Instance.LoadScene("Game");
        }
        else
        {
            Debug.LogError("Multiplayer instance is not available.");
        }
    }

    // Connect to an existing room
    public void Connect()
    {
        if (Multiplayer.Instance != null)
        {
            print("Join Attempted");
            Multiplayer.Instance.JoinFirstAvailable(); // Use Multiplayer.Instance
            Multiplayer.Instance.LoadScene("Game");
        }
        else
        {
            Debug.LogError("Multiplayer instance is not available.");
        }
    }

    public void RespawnFunction()
    {
        Multiplayer.Instance.LoadScene("Menu");
    }
}
