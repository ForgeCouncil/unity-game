using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScale : MonoBehaviour
{
    int maxHP, increase;
    private int currentHP = 100; //starts with 100 HP, proceeds to keep track of HP
    int maxHealth = 100; //start with max of 100 HP, proceeds to keep track of max HP
    int HPStartWidth = 98; //width of health bar (pixels) 
    float HPCurrentWidth = 98; //current width of the health bar (98 pixels for original HP bar)
    float offset = 30;
    float ratio;
    public Vector3 pos;
    public HealthBar healthBar;
    public PlayerScript playerScript;
    
    void Start () {
         pos= transform.position;
         Debug.Log("pos is " + pos);
     }

    void Update()
    {
        currentHP = playerScript.currentHealth;
    }

    public void IncreaseHealthBar(int increaseHP) //increase HP by set value
    {
        maxHealth += increaseHP; //increase HP for the class
        increase = increaseHP; //how much the new increase is 
                
        healthBar.SetMaxHealth(maxHealth); //increase max HP in healthbar script (GUI)
        playerScript.maxHealth = maxHealth;
        MaxHealth(maxHealth); //scaling function

        playerScript.currentHealth += increase; //increase max HP in player script
        healthBar.SetHealth(playerScript.currentHealth); //set health to the new value
    }

    public void MaxHealth(int maxhealth)
    {
        maxHP = maxhealth;
        
        ratio = (maxHP/100f); //ratio is used to determine how much to increase the health bar
        //Debug.Log("ratio is " + ratio);
        HPCurrentWidth = HPStartWidth * ratio; //find new width (in pixels) of health bar's new size
        //Debug.Log("current width is " + HPCurrentWidth);
        offset = ((HPCurrentWidth/2)+28); //finds where the center of the health bar should be on x-axis (center of health bar + offset from the side of the screen (28 pixels))
        //Debug.Log("offset is " + offset);
        transform.localScale = new Vector3(ratio, 1, 1);
        transform.position = new Vector3(offset, 27f, 1);
    }

}
