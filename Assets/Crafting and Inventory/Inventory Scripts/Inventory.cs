//Base script for inventory management and interaction with game objects.
using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //Making items and slots a serialized thing.
    [SerializeField] List<Item> items;
    [SerializeField] Transform itemsParent;
    [SerializeField] ItemSlot[] itemSlots;

    //Look at ItemSlot script's IPointerClick line and similar event.
    
    public event Action<Item> OnItemRightClickedEvent;

    //Known as an "awake event". "Listeners" are contained below it.
    private void Awake()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            //"To add a listener, we just use the '+=' operator and assign a mthod with the same signature as the event."
            itemSlots[i].OnRightClickEvent += OnItemRightClickedEvent;
        }
    }

    //Putting items into the next sequential item slot.
    private void OnValidate()
   {
       if (itemsParent != null)
            itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();

        RefreshUI();
   }

    //Changing the sprites for the item slots to the sprites of the newly added items. Probably. I'm a little confused by this one.
    private void RefreshUI()
    {
        int i = 0;
        
        for (; i < items.Count && i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = items[i];
        }

        for (; i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = null;
        }
    }

    //Adding items to inventory.
    public bool AddItem(Item item)
    {
        if (IsFull())
            return false;

        items.Add(item);
        RefreshUI();
        return true;
    }

    //Removing items.
    public bool RemoveItem(Item item)
    {
        if (items.Remove(item))
        {
            RefreshUI();
            return true;
        }
        return false;
    }

    //Checking to see if the inventory still has slots remaining.
    public bool IsFull()
    {
        return items.Count >= itemSlots.Length;
    }
}