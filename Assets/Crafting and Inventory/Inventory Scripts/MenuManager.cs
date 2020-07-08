using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject inventoryMenu;
    private bool inMenu = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryMenu.gameObject.SetActive(!inventoryMenu.activeSelf);
            
            //Freeze movements and free up cursor when menu is up
            inMenu = !inMenu;
            if (inMenu == true)
                print("Menu is up, freeze controls and free up the cursor.");
        }
    }
}
