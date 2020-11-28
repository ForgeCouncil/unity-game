using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brew : MonoBehaviour
{
    
    ScriptableObject Consumable;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("b"))
        {
            NewPotion CreateInstance();
        }
    }
}
