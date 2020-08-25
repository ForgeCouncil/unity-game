using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    
    public GameObject Inventory;

    public Transform playerBody;

    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update() //Added if statements to "switch" cursor from directional to UI manipulation. -Ian 08/15/20
    {
        if(Inventory.activeSelf == false)
        {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
        }

        if(Inventory.activeSelf == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if(Inventory.activeSelf == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
