using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public Vector3 outLocation = new Vector3(100, 100, 100);
    private int sceneID;
    public enum SceneTarget
    {
        StartingArea, Duncan
    }
    public SceneTarget portalTarget;

    void Start()
    {
        if(portalTarget == SceneTarget.Duncan)
        {
            sceneID = 1;
        }

        if(portalTarget == SceneTarget.StartingArea)
        {
            sceneID = 0;
        }
    }

    void OnTriggerEnter(Collider player)
    {
        //$5 to anyone that can figure out why the player maintains its transform 
        //when it goes through the portal even with the following line active. >_<
        //player.transform.position = outLocation;

        if(player.tag == "Player")
        {
            SceneManager.LoadScene(sceneID);
        }
    }
}
