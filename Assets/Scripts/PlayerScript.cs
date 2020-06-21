using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar_ healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)) //if "k" is pressed player takes 10 damage
        {
            Damage(10);
        }
        if(Input.GetKeyDown(KeyCode.H)) //if "H" is pressed player recieves 20 HP
        {
            Heal(20);
        }
        if (currentHealth > maxHealth) //player can't exceed max health (100)
            {
                currentHealth = maxHealth;
                healthBar.SetHealth(currentHealth);
            }
        else if ( currentHealth < 0) //player can't go below min health (0)
        {
            currentHealth = 0;
            healthBar.SetHealth(currentHealth);
        }
    }

    void Damage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    void Heal(int heal)
    {
        currentHealth += heal;

        healthBar.SetHealth(currentHealth);
    }
}
