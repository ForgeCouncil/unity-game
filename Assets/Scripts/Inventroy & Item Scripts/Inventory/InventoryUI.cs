using UnityEngine;
//https://www.youtube.com/watch?v=YLhj7SfaxSE&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7&index=7

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public Transform itemsParentBrewing;
    public Transform itemsParentQuest;
    public GameObject inventoryUI;
    public GameObject brewingUI;
    public GameObject questUI;

    InventorySlot[] slots;
    BrewingSlot[] brewingSlots;
    
    Inventory inventory;
    BrewingMenu brewingMenu;
    QuestMenu questMenu;
    
    public float mouseSensitivity = 50f;

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        brewingMenu = BrewingMenu.instance;
        brewingMenu.onItemChangedCallback += UpdateBrewingUI;

        questMenu = QuestMenu.instance;


        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        brewingSlots = itemsParentBrewing.GetComponentsInChildren<BrewingSlot>();
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

        //Quest Q button
        if (Input.GetKeyDown(KeyCode.Q) || (Input.GetKeyDown(KeyCode.Escape) && questUI.activeSelf == true))
        {
            questUI.SetActive(!questUI.activeSelf);
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

    void UpdateBrewingUI ()
    {
        for (int i = 0; i <brewingSlots.Length; i++)
        {
            if (i < brewingMenu.items.Count)
            {
                brewingSlots[i].AddItem(brewingMenu.items[i]);
            }
            
            else
            {
                brewingSlots[i].ClearSlot();
            }
        }
    }
}