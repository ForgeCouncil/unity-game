using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerMove : MonoBehaviour {
    public CharacterController controller;

    GameObject firstPersonPlayer;

    public float speed = 12f;
    public float speedMod = 1f;
    public float jumpSpeed;
    public float gravity = -9.81f;
    public float jumpHeight = 6f;

    public float slopeForce;
    public float slopeForceRayLength;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    public Vector3 windMove;
    
    void Start() {
        jumpSpeed = (2 * speed / 3);
    }

    // Update is called once per frame
    void Update() {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) {
            velocity.y = 0f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * x + transform.forward * z) + windMove;

        controller.Move(move * speed * Time.deltaTime * speedMod);

        if ((x != 0 || z != 0) && OnSlope())
            controller.Move(Vector3.down * controller.height / 2 * slopeForce * Time.deltaTime);
        if (Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        if (isGrounded) {
            controller.Move(move * jumpSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded) {
            speedMod = (speedMod * 1.2f);
            controller.Move(move * speedMod * Time.deltaTime);
        }
        speedMod = 1f;

        velocity.y += gravity * Time.deltaTime * 1.5f;
        controller.Move(velocity * Time.deltaTime);


        bool OnSlope() {
            if (isGrounded)
                return true;

            RaycastHit hit;

            if (Physics.Raycast(transform.position, Vector3.down, out hit, controller.height / 2 * slopeForceRayLength)) {
                if (hit.normal != Vector3.up) return true;
            }
            return false;
        }

    }

    public void Teleport(Vector3 destination) {
        controller.enabled = false;
        controller.transform.position = destination;
        controller.enabled = true;
    }

}