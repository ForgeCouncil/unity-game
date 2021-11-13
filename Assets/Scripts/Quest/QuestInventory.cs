using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestInventory : QuestEvent
{

    public List<string> requiredItems;

    public void OnChange()
    {
        if (!isAvailable) return;
        List<Item> currentItems = Inventory.instance.items;
        bool incomplete = false;
        incomplete = requiredItems.Exists(requiredItemName => !currentItems.Exists(item => item.name == requiredItemName));
        if (!incomplete) CompleteObjective();
    }
    void Awake()
    {
        Inventory.instance.onItemChangedCallback += OnChange;
    }
}
