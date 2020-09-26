using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // used to interact with the health bar (graphic)

public class StaminaBar : MonoBehaviour
{
    public Slider slider2; 
    public Gradient gradient2;
    public Image fill2;
    private Vector3 scaleChange, positionChange;
    

    void start() {
        slider2.value = 100; //sets the health bar to that value
    }

    public void SetMaxStamina(int stamina)
    {
        slider2.maxValue = stamina; //sets health bar's max to maxHealth 
        
        fill2.color = gradient2.Evaluate(1f); //allows the health bar to go from green to yellow to red
    }

    public void SetStamina(int stamina)
    {
        slider2.value = stamina; //changes health bar's value to new health value

        fill2.color = gradient2.Evaluate(slider2.normalizedValue); // updates the color of the health bar
    }

}
