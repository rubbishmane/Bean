using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    
    [SerializeField] internal GameObject[] guns;

    [SerializeField] private GameObject crossHairObject;

    [SerializeField] internal Sprite defaultCH;
    Image CH;
    [SerializeField] internal Sprite ch;
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
                ClearEquipt();
                guns[0].SetActive(true);
                SetCrossHair(0);
                break;
            case "2":
                ClearEquipt();
                guns[1].SetActive(true);
                SetCrossHair(1);
                break;
            case "3":
                ClearEquipt();
                guns[2].SetActive(true);
                SetCrossHair(2);
                break;
            case "4":
                ClearEquipt();
                guns[3].SetActive(true);
                SetCrossHair(3);
                break;
            case "5":
                ClearEquipt();
                guns[4].SetActive(true);
                SetCrossHair(4);
                break;   

            default:
                ClearEquipt();
                break;   
        }    
    }

    public void ClearEquipt()
    {
        for (int i = 0; i < guns.Length; i++)
        {
            guns[i].SetActive(false);
        }
    }

    private void SetCrossHair(int index)
    {
        spriteRenderer.sprite = guns[index].transform.GetComponent<Gun>().crossHair;
        spriteRenderer.size = guns[index].transform.GetComponent<Gun>().chSize;
    }
    
}