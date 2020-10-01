using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCrouch : MonoBehaviour
{
   CharacterController characterCollider;

   GameObject firstPersonPlayer;
   playerMove moveRef;
  


float crouchHeight;
float height;

float nSpeed;
float crouchSpeed;




    void Start()
    {
        characterCollider = gameObject.GetComponent<CharacterController> ();
        moveRef = GetComponent<playerMove>();
        nSpeed = moveRef.speed;
        height = characterCollider.height;
        crouchSpeed = (2*nSpeed/3);
        crouchHeight = (characterCollider.height/2);
        
    }

    
    void Update()
    {
        
        
        if (Input.GetKey(KeyCode.LeftControl)){
            characterCollider.height = crouchHeight;
            moveRef.speed = crouchSpeed;
            

           
        
        }
        else {
            characterCollider.height = height;
            moveRef.speed = nSpeed;
          
        }
    }
}
