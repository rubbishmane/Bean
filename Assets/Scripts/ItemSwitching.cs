using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSwitching : MonoBehaviour
{

    public int selectedItem = 0;

    // Start is called before the first frame update
    void Start()
    {
        SelectItem();   
    }

    // Update is called once per frame
void Update()
{
    int previousSelectedItem = selectedItem;

    if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.Alpha1))
    {
        selectedItem = 0;
    }
        if (transform.childCount >= 2 && Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.Alpha2))
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
        int i = 0;
        foreach (Transform item in transform)
        {
            if (i == selectedItem)
                item.gameObject.SetActive(true);
            else
                item.gameObject.SetActive(false);
            i++;
        }
    }
}

