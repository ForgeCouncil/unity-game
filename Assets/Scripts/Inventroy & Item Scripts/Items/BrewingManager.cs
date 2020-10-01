using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrewingManager : MonoBehaviour
{
    public GameObject brewedPotion;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            Instantiate(brewedPotion);
            Debug.Log("Brewed a potion?");
        }
    }
}
