using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    //multiplier
    public float potency = 5;

    //particles
    public GameObject particles;

    //Check for collision with potion
    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider player)
    {
        // call particles
        Instantiate(particles, transform.position, transform.rotation);
        
        //size
        player.transform.localScale *= potency;
        
        //remove potion from screen/inventory
        Destroy(gameObject);
    }
}
