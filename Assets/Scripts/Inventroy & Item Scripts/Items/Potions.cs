using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Potion", menuName = "Inventory/Potion")]
public class Potions : Item
{
    public int Duration;
    public int Potency;
    public int jumpMod = 0;
    public Effects[] effects;



    public override void Use()
    {
        base.Use();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<playerMove>().jumpHeight += jumpMod;
        RemoveFromInventory();
    }

    public enum Effects {Wisdom, Strength, Dexterity, Charisma, Intelligence, Constitution};
}