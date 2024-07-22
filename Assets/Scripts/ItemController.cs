using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    
    public GameObject[] items;
    void Start()
    {
         for (int i = 0; i <= items.Length; i++)
        {
            items[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        string s = Input.inputString;
        switch (s)
        {
            case "Alpha1":
                ClearEquipt();
                items[0].SetActive(true);
                break;
            case "Alpha2":
                ClearEquipt();
                items[1].SetActive(true);
                break;
            case "Alpha3":
                ClearEquipt();
                items[2].SetActive(true);
                break;
            case "Alpha4":
                ClearEquipt();
                items[3].SetActive(true);
                break;
            case "Alpha5":
                ClearEquipt();
                items[4].SetActive(true);
                break;    
        }    
    }

    public void ClearEquipt()
    {
        for (int i = 0; i <= items.Length; i++)
        {
            items[i].SetActive(false);
        }
    }
    
}