using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindForce : MonoBehaviour
{
    public GameObject BlownThing;
    public Vector3 WindDirection;
    public float windSpeed = 2;

    public bool randomWind;
    public Transform windicator;
    
    void Start()
    {
        BlownThing = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        //BlownThing.GetComponent<Rigidbody>().AddForce(WindDirection * windSpeed);
        
        if(Input.GetKeyDown(KeyCode.U) && randomWind == true)
        {
            WindDirection = new Vector3((Random.Range(-1.0f, 1.0f)), 0,(Random.Range(-1.0f, 1.0f)));
        }

        if(Input.GetKeyDown(KeyCode.N) && randomWind == true)
        {
            WindDirection = new Vector3(0,0,0);
        }

        if(windSpeed > 0)
        {
            BlownThing.GetComponent<playerMove>().windMove = WindDirection;
        }
    }
}
