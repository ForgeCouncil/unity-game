using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

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

    public List<Item> items = new List<Item>();

    public GameObject brewButtonPanel;
    public Button brewButton;
    public GameObject resultSlot;


    public void Start ()
    {
        brewButtonPanel = GameObject.Find("Brewing/BrewButtonPanel");
        resultSlot = GameObject.Find("Brewing/ItemsParent/ResultSlot");
        resultSlot.SetActive(false);
        
        //brewButton = brewButtonPanel.GetComponent<Button>();
    }
    
    public bool Add (Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                return false;
            }
            
            items.Add(item);

            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }

        return true;
    }

    public void Remove (Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
    }

    public void Update()
    {
        if (items.Count == 4)
        {
            brewButton.interactable = true;
            resultSlot.SetActive(true);
        }

        else
        {
            brewButton.interactable = false;
        }
    }

    public void Brew()
    {
        if (items.Count == 4 && brewButtonPanel.activeSelf && resultSlot.activeSelf)
        {
            
            
            //check for recipe
                // loop through array
                // find id of each ingredient in array
                // check for potion with those requirements
                // if failed, make beef lemonade

            //instantiate potion
            //add instantiated potion to inventory
        }
    }
}
