using Alteruna;
using UnityEngine;
using UnityEngine.UI;


using TMPro;

public class scripts : AttributesSync
{
    private Multiplayer multiplayer;

    public GameObject loadImage;
    public TextMeshProUGUI loadingText;

    private bool isConnected = false;
    void Awake()
    {
        gameObject.SetActive(true);
    }
    void Start()
    {
        multiplayer = GetComponent<Multiplayer>();

        if (multiplayer != null)
        {
            multiplayer.OnConnected.AddListener(OnMultiplayerConnected);
        }
        else
        {
            Debug.LogError("Multiplayer component not found!");
        }
    }

    void OnMultiplayerConnected(Multiplayer multiplayer, Endpoint endpoint)
    {
        isConnected = true;
        Debug.Log("Multiplayer connected!");
        InvokeRemoteMethod("DestroyEverything", UserId.AllInclusive);
        Destroy(gameObject);
    }

    public bool IsConnected()
    {
        return isConnected;
    
    }

    [SynchronizableMethod]
    void DestroyEverything()
    {
        Destroy(loadingText);
        Destroy(loadImage);
        Destroy(gameObject);
    }
}
