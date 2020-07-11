//Manages the items in the brewing panel.
using System;
using UnityEngine;

public class BrewingPanel : MonoBehaviour
{
    [SerializeField] Transform brewSlotsParent;
    [SerializeField] BrewSlots[] brewSlots;

    public event Action<Item> OnItemRightClickedEvent;

    //Copied from Inventory script.
    private void Awake()
    {
        for (int i = 0; i < brewSlots.Length; i++)
        {
            //"To add a listener, we just use the '+=' operator and assign a mthod with the same signature as the event."
            brewSlots[i].OnRightClickEvent += OnItemRightClickedEvent;
        }
    }

    private void OnValidate()
    {
        brewSlots = brewSlotsParent.GetComponentsInChildren<BrewSlots>();
    }

    //Adds ingredients to brew slots based on length of array above, like other panel.
    public bool AddItem(IngredientItem item, out IngredientItem previousItem)
    {
        for (int i = 0; i < brewSlots.Length; i++)
        {
            if (brewSlots[i].ItemType == item.ItemType)
            {
                //Assigning previous item to an out variable, checking if slot is open.
                previousItem = (IngredientItem)brewSlots[i].Item;
                brewSlots[i].Item = item;
                return true;
            }
        }
        previousItem = null;
        return false;
    }

    //Removes ingredients from brew.
    public bool RemoveItem(IngredientItem item)
    {
        for (int i = 0; i < brewSlots.Length; i++)
        {
            if (brewSlots[i].Item == item)
            {
                brewSlots[i].Item = null;
                return true;
            }
        }
        return false;
    }
}
