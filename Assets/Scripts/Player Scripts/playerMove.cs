using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerMove : MonoBehaviour
{
    public CharacterController controller;
    
     GameObject firstPersonPlayer;


    public float speed = 12f;
    public float jumpSpeed;
    public float gravity = -9.81f;
    public float jumpHeight = 6f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    void Start(){
        
       jumpSpeed = (2*speed/3);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0){
            velocity.y = 0f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        if(isGrounded){
            controller.Move(move * jumpSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.LeftShift) && isGrounded){
            speed = (speed *2);
            controller.Move(move * speed * Time.deltaTime);
        }
        
        velocity.y += gravity * Time.deltaTime * 1.5f;
        controller.Move(velocity * Time.deltaTime);
    }
}