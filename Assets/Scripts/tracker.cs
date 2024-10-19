using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class tracker : MonoBehaviour
{
    public int wins;
    public int losses;
    public string wiMessage;
    public string lostMessage;
    bool won;
    TextMeshProUGUI lossesString;
    TextMeshProUGUI winString;
    TextMeshProUGUI message;
    string currentSceneName;

    void Start()
    {
        if(currentSceneName == "Menu")
        {
            lossesString = GameObject.Find("losestring").GetComponent<TextMeshProUGUI>();
            winString = GameObject.Find("winstring").GetComponent<TextMeshProUGUI>();
            message = GameObject.Find("message").GetComponent<TextMeshProUGUI>();
        }
    }
    void Update()
    {   
        
        currentSceneName = SceneManager.GetActiveScene().name;
        
    }
    // Start is called before the first frame update
    public void Win()
    {
        wins++;
        winString.text = "Wins: " + wins;
        message.text = wiMessage;

    }

    public void Lose()
    {
        losses++;
        lossesString.text = "Loses: " + losses;
        message.text = lostMessage;
    }
}
