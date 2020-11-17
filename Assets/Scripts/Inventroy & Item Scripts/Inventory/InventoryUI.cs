using UnityEngine;
//https://www.youtube.com/watch?v=YLhj7SfaxSE&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7&index=7

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;

    InventorySlot[] slots;
    
    Inventory inventory;
    
    public float mouseSensitivity = 50f;

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
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
    }

    void UpdateUI ()
    {
        for (int i = 0; i < slots.Length; i++)
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
}