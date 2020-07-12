//Script that manages the inventory menu, toggling it with "I" in game.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject Menu;
    public KeyCode Key;

    void Update()
    {
        if (Input.GetKeyDown(Key))
        {
            Menu.gameObject.SetActive(!Menu.activeSelf);
            GameObject.Find("Camera").GetComponent<playerLook>().enabled = !(GameObject.Find("Camera").GetComponent<playerLook>().enabled);
            
        }
    }
}
