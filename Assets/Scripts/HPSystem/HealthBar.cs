using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // used to interact with the health bar (graphic)

public class HealthBar : MonoBehaviour
{
    public Slider slider; 
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health; //sets health bar's max to maxHealth 
        slider.value = health; //sets the health bar to that value

        fill.color = gradient.Evaluate(1f); //allows the health bar to go from green to yellow to red
    }

    public void SetHealth(int health)
    {
        slider.value = health; //changes health bar's value to new health value

        fill.color = gradient.Evaluate(slider.normalizedValue); // updates the color of the health bar
    }
}
