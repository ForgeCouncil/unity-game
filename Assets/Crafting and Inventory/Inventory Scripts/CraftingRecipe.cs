//Defines crafting recepies as structures that take two ingredients as components and output a potion.
//It might be important later to limit the types of items recipies can recieve to ingredients only in a formal way.
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [Serializable]
public struct ItemAmount
{
    public Item Item;
    [Range(1, 999)]
    public int Amount;
}
    [CreateAssetMenu]
public class CraftingRecipe : ScriptableObject
{
    public List<ItemAmount> Materials;
    public List<ItemAmount> Result;

}
