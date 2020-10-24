using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pasueMenuUI;

    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
                //Cursor.lockState = CursorLockMode.None;
                //pasueMenuUI.SetActive(!pasueMenuUI.activeSelf);
            }
            else 
            {
                Pause();
                //Cursor.lockState = CursorLockMode.Locked;
                //pasueMenuUI.SetActive(!pasueMenuUI.activeSelf);
            }
        }
        
        if(pasueMenuUI.activeSelf == false)
        {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
        }

        if(pasueMenuUI.activeSelf == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if(pasueMenuUI.activeSelf == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void Resume()
    {
        pasueMenuUI.SetActive(false);
        //Time.timeScale = 1f; //pauses time
        GameIsPaused = false;
        
    }

    void Pause()
    {
        pasueMenuUI.SetActive(true);
        //Time.timeScale = 0f; //pauses time
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading menu...");
    }

    public void QuitGame()
    {
        Debug.Log("Quiting game...");
    }
}
