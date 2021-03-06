using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;
    public int maxStamina = 100;
    public int currentStamina = 100;
    public HealthBar healthBar;
    public HealthBarScale healthBarScale1;
    public HealthBarScale healthBarScale2;
    public StaminaBar staminaBar;
    public StaminaBarScale staminaBarScale1;
    public StaminaBarScale staminaBarScale2;
    public Vector3 teleportPos;
    public float tickTime;
    int layer_poison = 10;
    

    void Start()
    {
        currentHealth = maxHealth; //set players health to max (full health bar)
        healthBar.SetMaxHealth(maxHealth); //sets the health bar's max to maxHealth
    }

    void Update()
    {


        if(Input.GetKeyDown(KeyCode.J)) //if "J" is pressed player takes 10 damage
        {
            Damage(10);
        }
        if(Input.GetKeyDown(KeyCode.H)) //if "H" is pressed player recieves 20 HP
        {
            Heal(20);
        }
        if(Input.GetKeyDown(KeyCode.K)) //if "K" is pressed player max health increases by 25
        {
            healthBarScale1.IncreaseHealthBar(25);
            healthBarScale2.IncreaseHealthBar(25);
        }
        if(Input.GetKey(KeyCode.LeftShift)) //if "Lshift" is pressed player uses stamina
        {
            Run(1);//uses 1 stamina per tick (this is more of place holder than something permanent)
        }
        

        if (currentHealth > maxHealth) //player can't exceed max health (100 at start)
        {
            currentHealth = maxHealth;
            healthBar.SetHealth(currentHealth);
        }
        else if ( currentHealth < 0) //player can't go below min health (0)
        {
            currentHealth = 0;
            healthBar.SetHealth(currentHealth);
        }


        if (currentStamina > maxStamina) //player can't exceed max stamina (100 at start)
        {
            currentStamina = maxStamina;
            staminaBar.SetStamina(currentStamina);
        }
        else if ( currentStamina < 0) //player can't go below min health (0)
        {
            currentStamina = 0;
            staminaBar.SetStamina(currentStamina);
        }
        else if ((currentStamina < maxStamina) && (currentStamina >= 0) && !Input.GetKey(KeyCode.LeftShift))
        {
            currentStamina++;//stamina regen script
            staminaBar.SetStamina(currentStamina); //update stamina bar
        }
    }

    public void Damage(int damage) //function to inflict damage to player
    {
        currentHealth -= damage;
        //healthBarScale.currentHP -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void Heal(int heal) // function to heal player
    {
        currentHealth += heal;
        //healthBarScale.currentHP += heal;
        healthBar.SetHealth(currentHealth);
    }

    public void Run(int runTime)
    {
        currentStamina -= runTime;
        staminaBar.SetStamina(currentStamina);
        // add player speed modifier here
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
        if (collisionInfo.gameObject.name == "HealthArea")
        {
            tickTime -= Time.deltaTime;

            Debug.Log ("Player triggered");

            if (tickTime <= 0)
            {
                Debug.Log ("Player healed");
                Heal(10);
                tickTime = 1.0f;
            }
        }

    }
}
