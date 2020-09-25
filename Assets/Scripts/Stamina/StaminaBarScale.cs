using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBarScale : MonoBehaviour
{
    int maxStam, increase;
    private int currentStamina = 100; //starts with 100 HP, proceeds to keep track of HP
    int maxStamina = 100; //start with max of 100 HP, proceeds to keep track of max HP
    int StaminaStartWidth = 98; //width of health bar (pixels) 
    float StaminaCurrentWidth = 98; //current width of the health bar (98 pixels for original HP bar)
    float offset = 30;
    float ratio;
    public Vector3 pos;
    public StaminaBar staminaBar;
    public PlayerScript playerScript;
    // Start is called before the first frame update

    void Start () {
         pos= transform.position;
         Debug.Log("pos is " + pos);
     }

    void Update()
    {
        currentStamina = playerScript.currentStamina;
    }

    public void IncreaseStaminaBar(int increaseStamina) //increase HP by set value
    {
        maxStamina += increaseStamina; //increase HP for the class
        increase = increaseStamina; //how much the new increase is 
                
        staminaBar.SetMaxStamina(maxStamina); //increase max HP in healthbar script (GUI)
        playerScript.maxStamina = maxStamina;
        MaxStamina(maxStamina); //scaling function

        playerScript.currentStamina += increase; //increase max HP in player script
        staminaBar.SetStamina(playerScript.currentStamina); //set health to the new value
    }

    public void MaxStamina(int maxstamina)
    {
        maxStam = maxstamina;
        
        ratio = (maxStam/100f); //ratio is used to determine how much to increase the health bar
        //Debug.Log("ratio is " + ratio);
        StaminaCurrentWidth = StaminaStartWidth * ratio; //find new width (in pixels) of health bar's new size
        //Debug.Log("current width is " + HPCurrentWidth);
        offset = ((StaminaCurrentWidth/2)+28); //finds where the center of the health bar should be on x-axis (center of health bar + offset from the side of the screen (28 pixels))
        //Debug.Log("offset is " + offset);
        transform.localScale = new Vector3(ratio, 1, 1);
        transform.position = new Vector3(offset, 27f, 1);
    }
}
