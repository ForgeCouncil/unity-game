//https://www.youtube.com/watch?v=HQNl3Ff2Lpo&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7&index=5
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    //all kinds of tiems will inheret thses functions
    // Potions for example can have seperate results for their own "use" functions
    // for now, clicking an inventory slot button runs Use() and adds to the Brewing menus, 
    // but later, we can make it so that only ingredients can be transfered this way whil potions are consumed
    public virtual void Use()
    {
        //Use the item
        //something might happen

        Debug.Log("Using " + name);
    } 

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }

    
}
