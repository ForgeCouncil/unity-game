//Handels the movings in and out, to and from, of items in the brew menu and inventory.
using UnityEngine;

//IPointerClickHandler detects clicks and mouse movement.
public class InventoryManager : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] BrewingPanel brewingPanel;

    //If confused, see comments on Inventory script's own Awake event.
    private void Awake()
    {
        inventory.OnItemRightClickedEvent += EquipFromInventory;
        brewingPanel.OnItemRightClickedEvent += UnequipFromBrewPanel;
    }

    //This checks that the only type of item we are manipulating with the click 
    //for the equip action script are those which can be used to drink or brew.
    private void EquipFromInventory(Item item)
    {
        if (item is IngredientItem)
        {
            Equip((IngredientItem)item);
        }
    }

    private void UnequipFromBrewPanel(Item item)
    {
        if (item is IngredientItem)
        {
            Unequip((IngredientItem)item);
        }
    }


    //Moving from inventory to brew panel. 
    //For now, "Equiping". But maybe we should agree on a different term later? 
    //"Adding", "Mixing", "Muddling"? @bryce, @ricky, @jonJon
    public void Equip(IngredientItem item)
    {
        if (inventory.RemoveItem(item))
        {
            IngredientItem previousItem;
            if (brewingPanel.AddItem(item, out previousItem))
            {
                //If something is in the desired slot already, return to inventory.
                if (previousItem != null)
                {
                    inventory.AddItem(previousItem);
                }
            }

            //If we can't put it in that slot for some other reason, also return to inventory.
            else
            {
                inventory.AddItem(item);
            }
        }
    }

    //"Unequipping", or moving from brew panel to inventory. 
    //*Note* only if ingredients are NOT consumed. Consuming ingredients should... 
    //...destroy them and will be handledm in the recipe structure script.
    public void Unequip(IngredientItem item)
    {
        if (!inventory.IsFull() && brewingPanel.RemoveItem(item))
        {
            inventory.AddItem(item);
        }
    }
}
//Wrote a feckin novel on this one.