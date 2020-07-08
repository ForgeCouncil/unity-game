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
