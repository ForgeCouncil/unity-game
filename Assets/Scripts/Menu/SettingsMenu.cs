using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; //used for cuntrolling volume level
using UnityEngine.UI; //used for resolutions

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;

    Resolution[] resolutions;

    void Start ()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions(); //clear resolution options from unity (default resolutions)

        List<string> options = new List<string>();

        int currentResoltionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].width == Screen.currentResolution.height)
            {
                currentResoltionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options); //add our preset resolutions back into unity for the player to select
        resolutionDropdown.value = currentResoltionIndex; //set resolution to the highest allowed
        resolutionDropdown.RefreshShownValue(); //refresh resolution
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume); // sets volume audio mixer to the value in game
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void Back()
    {
        //SceneManager.LoadScene(sceneID);
    }    
}
