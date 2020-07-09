using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCrouch : MonoBehaviour
{
   CharacterController characterCollider;

float crouchHeight;
float height;

    void Start()
    {
        characterCollider = gameObject.GetComponent<CharacterController> ();
        height = characterCollider.height;
        crouchHeight = (characterCollider.height/2);
    }

    
    void Update()
    {
        
        
        if (Input.GetKey(KeyCode.LeftControl)){
            characterCollider.height = crouchHeight;
        
        }
        else {
            characterCollider.height = height;
        }
    }
}
