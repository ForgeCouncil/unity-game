﻿using UnityEngine;
//https://www.youtube.com/watch?v=YLhj7SfaxSE&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7&index=7

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;
    public GameObject brewingUI;

    InventorySlot[] slots;
    BrewingSlot[] brewingSlots;
    
    Inventory inventory;
    BrewingMenu brewingMenu;
    
    public float mouseSensitivity = 50f;

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        brewingMenu = BrewingMenu.instance;
        //brewingMenu.onItemChangedCallback += UpdateBrewingUI;


        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        brewingSlots = itemsParent.GetComponentsInChildren<BrewingSlot>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) || (Input.GetKeyDown(KeyCode.Escape) && inventoryUI.activeSelf == true))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }

        if(inventoryUI.activeSelf == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        if(inventoryUI.activeSelf == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }

        //Brewing menu dups
        if (Input.GetKeyDown(KeyCode.B) || (Input.GetKeyDown(KeyCode.Escape) && brewingUI.activeSelf == true))
        {
            brewingUI.SetActive(!brewingUI.activeSelf);
        }

        if(brewingUI.activeSelf == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        if(brewingUI.activeSelf == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void UpdateUI ()
    {
        for (int i = 0; i <slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    // void UpdateBrewingUI ()
    // {
    //     for (int i = 0; i <brewingSlots.Length; i++)
    //     {
    //         if (i < brewingMenu.ingredients.Count)
    //         {
    //             brewingSlots[i].AddItem(brewingMenu.ingredients[i]);
    //         }
            
    //         else
    //         {
    //             brewingSlots[i].ClearSlot();
    //         }
    //     }
    // }
}