using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public float tickTime;

    void Start()
    {
        currentHealth = maxHealth; //set players health to max (full health bar)
        healthBar.SetMaxHealth(maxHealth); //sets the health bar's max to maxHealth
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

    void Damage(int damage) //function to inflict damage to player
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    void Heal(int heal) // function to heal player
    {
        currentHealth += heal;

        healthBar.SetHealth(currentHealth);
    }

    void OnTriggerStay (Collider collisionInfo)
    {
        if (collisionInfo.gameObject.name == "PoisonArea")
        {
            tickTime -= Time.deltaTime;

            Debug.Log ("Player triggered");

            if (tickTime <= 0)
            {
                Debug.Log ("Player damaged");
                Damage(10);
                tickTime = 1.0f;
            }
        }

    }
}
