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
}
