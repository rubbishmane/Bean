using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    
    [SerializeField] internal GameObject[] guns;

    [SerializeField] private GameObject crossHairObject;

    [SerializeField] internal Sprite defaultCH;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = crossHairObject.GetComponent<SpriteRenderer>();

    }
    void Start()
    {
        for (int i = 0; i < guns.Length; i++)
        {
            print(i);
            guns[i].SetActive(false);
        }
        SetCrossHair(4);
    }

    // Update is called once per frame
    void Update()
    {
        string s = Input.inputString;
        print(s);
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


    // Function to deactivate all guns and set a new one active
    private void SwitchGun(int index)
    {
        ClearEquipped();
        if (index >= 0 && index < guns.Length)
        {
            guns[index].SetActive(true);
            SetCrossHair(index);
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
                spriteRenderer.sprite = gun.crossHair;
            }
            else
            {
                Debug.LogError("Gun component missing on gun at index " + index);
            }
        }
        else
        {
            spriteRenderer.sprite = defaultCH;
        }
    }
    
}