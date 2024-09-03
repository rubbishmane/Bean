using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSwitching : MonoBehaviour
{

    public int selectedItem = 0;

    public GameObject[] items;

    // Start is called before the first frame update
    void Start()
    {
        SelectItem();   
    }

    // Update is called once per frame
void Update()
{
    int previousSelectedItem = selectedItem;

    if (Input.GetKey(KeyCode.E)) 
    {
        selectedItem = 0;
        
    }
        if (transform.childCount >= 2 && Input.GetKey(KeyCode.F))
    {
        selectedItem = 1;
    }
    

    if (previousSelectedItem != selectedItem)
    {
        SelectItem();
    }
}

    void SelectItem()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].SetActive(false);
        }
        if (selectedItem == 0 || selectedItem == 1)
        {
            items[selectedItem].SetActive(true);
        }
        else 
        {
            items[selectedItem].SetActive(false);
        }
    }
}

