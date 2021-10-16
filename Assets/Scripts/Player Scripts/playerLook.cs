using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    
    public GameObject Inventory;

    public GameObject PauseMenu;

    public Transform playerBody;

    float xRotation = 0f;
    // Start is called before the first frame update


    //respawn stuff
    public Transform target;
    float offsetZ;
    Vector3 lastTargetPosition;

    float nextTimeToSearch = 0;



    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        lastTargetPosition=target.position;
        offsetZ = (transform.position - target.position).z;
        transform.parent = null;
    }

    // Update is called once per frame
    void Update() //Added if statements to "switch" cursor from directional to UI manipulation. -Ian 08/15/20
    {
        if (target == null){
            FindPlayer();
            return;
        }

        if(Inventory.activeSelf == false)
        {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
        }

        // if(Inventory.activeSelf == true)
        // {
        //     Cursor.lockState = CursorLockMode.None;
        // }

        // if(Inventory.activeSelf == false)
        // {
        //     Cursor.lockState = CursorLockMode.Locked;
        // }
    }

    void FindPlayer()
    {
        if (nextTimeToSearch <= Time.time)
        {
            GameObject searchResult = GameObject.FindGameObjectWithTag ("Player");
            if ( searchResult != null)
            {
                target = searchResult.transform;
            }
            nextTimeToSearch = Time.time + 0.5f;
        }
    }
}
