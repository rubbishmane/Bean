using Alteruna;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : AttributesSync
{
    [SerializeField] internal GameObject[] guns;
    [SerializeField] private GameObject crossHairObject;
    [SerializeField] internal Sprite defaultCH;
    Image CH;
    private UIUpdater uIUpdater;
    public Alteruna.Avatar thisAvatar;

    // Sync the active gun index across the network
    
   [SynchronizableField] private int activeGunIndex = -1;

    void Awake()
    {
        thisAvatar = GetComponentInParent<Alteruna.Avatar>();
        crossHairObject = GameObject.Find("CrossHair");
        CH = crossHairObject.GetComponent<Image>();
    }

    void Start()
    {
        for (int i = 0; i < guns.Length; i++)
        {
            guns[i].SetActive(false);
        }
        SetCrossHair(4); // Default crosshair setup
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
        ClearEquipped();
        if (index >= 0 && index < guns.Length)
        {
            guns[index].SetActive(true);
            SetCrossHair(index);
            activeGunIndex = index; // Sync the active gun index
        }
    }

    public void ClearEquipped()
    {
        for (int i = 0; i < guns.Length; i++)
        {
            guns[i].SetActive(false);
        }
    }

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

    // Synchronize the active gun index across the network
    private void OnSyncedAttributeChange()
    {
        if (activeGunIndex >= 0 && activeGunIndex < guns.Length)
        {
            SwitchGun(activeGunIndex);
        }
    }
}
