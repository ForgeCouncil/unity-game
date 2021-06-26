using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindForce : MonoBehaviour
{
    public GameObject BlownThing;
    public Vector3 WindDirection;
    public bool windToggle;
    public Transform windicator;
    public Text windText;
    
    void Start()
    {
       // BlownThing = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered the" + gameObject.name + ".");
            BlownThing.GetComponent<playerMove>().windMove = WindDirection;
            windText.text = ("Wind direction " + WindDirection                                                                                   );
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            BlownThing.GetComponent<playerMove>().windMove = new Vector3(0,0,0);
            Debug.Log("Player left the" + gameObject.name + ".");
            windText.text = ("No wind");
        }
    }
}
