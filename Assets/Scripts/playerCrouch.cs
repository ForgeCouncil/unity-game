using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCrouch : MonoBehaviour
{
   CharacterController characterCollider;
    void Start()
    {
        characterCollider = gameObject.GetComponent<CharacterController> ();
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl)){
            characterCollider.height = 1.9f;
        }
        else {
            characterCollider.height = 3.8f;
        }
    }
}
