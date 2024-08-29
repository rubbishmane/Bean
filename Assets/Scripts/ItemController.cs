using Alteruna;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : AttributesSync
{
    [SerializeField] internal GameObject[] guns;
    private GameObject crossHairObject;
    [SerializeField] internal Sprite defaultCH;
    Image CH;
    private UIUpdater uIUpdater;
    public Alteruna.Avatar thisAvatar;
    public int currentGunIndex; 
    

    private const string MethodName = "SyncGun";

    
    

    void Awake()
    {   
        currentGunIndex = 0;
        thisAvatar = GetComponentInParent<Alteruna.Avatar>();
        crossHairObject = GameObject.Find("CrossHair");
        CH = crossHairObject.GetComponent<Image>();
    }

    void Start()
    {
        SwitchGun(0);
        
        for (int i = 0; i < guns.Length; i++)
        {
            guns[i].SetActive(false);
        }
        
    }

    void Update()
    {
        if (thisAvatar == null)
        {
            Debug.Log("Avatar is null");
        }
        else if (!thisAvatar.IsMe)
        {
            return;
        }

        string s = Input.inputString;
        switch (s)
        {
            case "1":
                SwitchGun(0);
                break;
            case "2":
                SwitchGun(1);
                break;
            case "3":
                SwitchGun(2);
                break;
            case "4":
                SwitchGun(3);
                break;
            case "5":
                SwitchGun(4);
                break;
            default:
                break;
        }
    }

    private void SwitchGun(int index)
    {
        // Sync the gun switch across all clients
        
        InvokeRemoteMethod(MethodName, UserId.AllInclusive, index);
    }

    // Method to clear all equipped guns
    public void ClearEquipped()
    {
        for (int i = 0; i < guns.Length; i++)
        {
            guns[i].SetActive(false);
        }
    }

    // Method to set the crosshair based on the gun index
    private void SetCrossHair(int index)
    {
        if (index >= 0 && index < guns.Length)
        {
            Gun gun = guns[index].GetComponent<Gun>();
            if (gun != null)
            {
                CH.sprite = gun.crossHair;
                CH.rectTransform.sizeDelta = gun.chSize;
            }
            else
            {
                Debug.LogError("Gun component missing on gun at index " + index);
            }
        }
        else
        {
            CH.sprite = defaultCH;
        }
    }

    // Method to be invoked on all clients to sync gun switch
    [SynchronizableMethod]
    public void SyncGun(int index)
    {
        ClearEquipped();
        if (index >= 0 && index < guns.Length)
        {
            guns[index].SetActive(true);
            SetCrossHair(index);
            currentGunIndex = index;
        }
    }
}
