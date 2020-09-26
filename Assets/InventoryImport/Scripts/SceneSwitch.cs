using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public Vector3 outLocation = new Vector3(100, 100, 100);

    void OnTriggerEnter(Collider player)
    {
        player.transform.position = outLocation;

        if(player.tag == "Player")
        {
            SceneManager.LoadScene(1);
        }
    }
}
