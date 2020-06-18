using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsMovement : MonoBehaviour
{
    public int speed = 13;
    public int jumpSpeed = 10;
    public int gravity = 9;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
         if (Input.GetKey("w"))
        {
            
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey("a"))
        {
           
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
         if (Input.GetKey("s"))
        {
            
             transform.Translate(-1 * Vector3.forward * Time.deltaTime * speed);

        }
        if (Input.GetKey("d"))
        {
            
             transform.Translate(-1 * Vector3.left * Time.deltaTime * speed);

        }
         if (Input.GetKey("e"))
        {
            
             transform.Translate(Vector3.down * Time.deltaTime * speed);

        }
         if (Input.GetKey("q"))
        {
           
             transform.Translate(-1 * Vector3.down * Time.deltaTime * speed);

    }
    if (Input.GetKey("space")){
        transform.Translate(Vector3.up * Time.deltaTime * jumpSpeed);
    }

    }
}