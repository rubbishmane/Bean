using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject startMenuPanel;
    public GameObject optionsMenuPanel;

    void Start()
    {
        ShowStartMenu();
    }

    public void PlayGame ()
    {
        SceneManager.LoadScene("LobbyFinder");
    }

    public void ShowStartMenu()
    {
        startMenuPanel.SetActive(true);
        optionsMenuPanel.SetActive(false);
    }

    public void ShowOptionsMenu()
    {
        startMenuPanel.SetActive(false);
        optionsMenuPanel.SetActive(true);
    }

    public void OnStartGame()
    {
        // Code to start the game
        Debug.Log("Start Game");
    }

    public void OnExitGame()
    {
        // Code to exit the game
        Debug.Log("Quit Application");
        Application.Quit();
    }
}
