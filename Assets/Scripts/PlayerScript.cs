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
            TakeDamage(10);
        }
        if(Input.GetKeyDown(KeyCode.H)) //if "H" is pressed player recieves 20 HP
        {
            HealPlayer(20);
        }
        if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
                healthBar.SetHealth(currentHealth);
            }
        else if ( currentHealth < 0)
        {
            currentHealth = 0;
            healthBar.SetHealth(currentHealth);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    void HealPlayer(int heal)
    {
        currentHealth += heal;

        healthBar.SetHealth(currentHealth);
    }

    void checkHealth(int currentHealth_)
    {

       // else 
           // currentHealth_ = currentHealth_;
        
        healthBar.SetHealth(currentHealth_);
    }
}
