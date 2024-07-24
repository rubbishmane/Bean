using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject startMenuPanel;
    public GameObject optionsMenuPanel;
    public GameObject createOrChoosePanel;
    public GameObject viewLobbyListPanel;
    public GameObject createGamePanel;

    void Start()
    {
        ShowStartMenu();
    }

    public void ShowStartMenu()
    {
        startMenuPanel.SetActive(true);
        optionsMenuPanel.SetActive(false);
        createOrChoosePanel.SetActive(false);
        viewLobbyListPanel.SetActive(false);
        createGamePanel.SetActive(false);

    }

    public void ShowOptionsMenu()
    {
        startMenuPanel.SetActive(false);
        optionsMenuPanel.SetActive(true);
        createOrChoosePanel.SetActive(false);
        viewLobbyListPanel.SetActive(false);
        createGamePanel.SetActive(false);
    }

    public void ShowCreateOrChooseMenu() 
    {
        startMenuPanel.SetActive(false);
        optionsMenuPanel.SetActive(false);
        createOrChoosePanel.SetActive(true);
        viewLobbyListPanel.SetActive(false);
        createGamePanel.SetActive(false);
    }

   public void ShowLobbyListMenu() 
    {
        startMenuPanel.SetActive(false);
        optionsMenuPanel.SetActive(false);
        createOrChoosePanel.SetActive(false);
        viewLobbyListPanel.SetActive(true);
        createGamePanel.SetActive(false);
    }
       public void ShowCreateGameMenu() 
    {
        startMenuPanel.SetActive(false);
        optionsMenuPanel.SetActive(false);
        createOrChoosePanel.SetActive(false);
        viewLobbyListPanel.SetActive(false);
        createGamePanel.SetActive(true);
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
