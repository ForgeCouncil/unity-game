//Defines the stat changing qualities of different items & potions. 
//Built before crafting system was, so this may become redundant or irrelevant.
using UnityEngine;

public enum ItemType //might not need this later or in this script
{
    Ingredient,
    Potion,
}

    [CreateAssetMenu]
public class IngredientItem : Item
{
    public int StrengthMod;
    public int ConstitutionMod;
    public int DexterityMod;
    public int WisdomMod;
    public int CharismaMod;
    public int LuckMod;

    [Space] //Inspector layout.
    
    public float StrengthModPercent;
    public float ConstitutionModPercent;
    public float DexterityModPercent;
    public float WisdomModPercent;
    public float CharismaModPercent;
    public float LuckModPercent;

    [Space]

    public ItemType ItemType;
}
