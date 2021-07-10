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
    public Rigidbody blownThingRB;
    public bool isBlowing;
    public float windStrength;
    //Make sure that the windStrength or the WindDirection is MUCH higher if the wind zone is pushing on the XZ axis. 
    //Y axis should be in the 10's, XZ should be in the 100's. Set in inspector.

    void Update()
    {
        if(isBlowing == true && blownThingRB != null)
        {
            blownThingRB.AddForce(WindDirection * windStrength);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Entered " + this.name + ".");
            blownThingRB = col.gameObject.GetComponent<Rigidbody>();
            isBlowing = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Exited " + this.name + ". No longer being blown.");
            blownThingRB = null;
            isBlowing = false;
        }
    }
}
