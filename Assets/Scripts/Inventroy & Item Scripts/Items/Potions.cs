using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Potion", menuName = "Inventory/Potion")]
public class Potions : Item
{
    public int Duration;
    public int Potency;
    public float jumpMod;
    public float speedMod;
    public bool Sticky;
    public Effects[] effects;



    public override void Use()
    {
        base.Use();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<playerMove>().jumpHeight += jumpMod;
        player.GetComponent<playerMove>().speedMod += speedMod;
        player.GetComponent<isSticky>().sticky = true;
        RemoveFromInventory();

        new WaitForSeconds(Duration); // wear off
        player.GetComponent<playerMove>().jumpHeight -= jumpMod;
        player.GetComponent<playerMove>().speedMod -= speedMod;
        player.GetComponent<isSticky>().sticky = false;
        Debug.Log("Potion has worn off after " + Duration + " seconds!");
    }

    public enum Effects {Wisdom, Strength, Dexterity, Charisma, Intelligence, Constitution};
}