using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrewingMenu : MonoBehaviour
{
    #region Singleton

    public static BrewingMenu instance;

    void Awake ()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Brewing Menu found!");
            return;
        }

        instance = this;
    }
    
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 4;

    public List<Item> ingredients = new List<Item>();

    public bool Add (Item item)
    {
        if (!item.isDefaultItem)
        {
            if (ingredients.Count >= space)
            {
                return false;
            }
            
            ingredients.Add(item);

            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }

        return true;
    }

    public void Remove (Item item)
    {
        ingredients.Remove(item);

        if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
    }
}
