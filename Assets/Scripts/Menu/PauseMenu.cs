using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pasueMenuUI;

    public float mouseSensitivity = 50f;

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
               
                
            }
            else 
            {
                Pause();
                
            }
        }
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.None;
        pasueMenuUI.SetActive(false);
        Time.timeScale = 1f; //pauses time
        GameIsPaused = false;
        
    }

    void Pause()
    {
        Cursor.lockState = CursorLockMode.Confined;
        pasueMenuUI.SetActive(true);
        Time.timeScale = 0f; //pauses time
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
