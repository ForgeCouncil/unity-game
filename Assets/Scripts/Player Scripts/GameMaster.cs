using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;
    void Start()
    {
      if (gm = null){
          gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameMaster>();
      }  
    }
    //PlayerScript playerScript;

    public Transform playerPrefab;
    public Transform spawnPoint;

    public GameObject firstPersonPlayer;
    public int spawnDelay = 2;

    public IEnumerator RespawnPlayer () {
        Debug.Log ("TODO: Add waiting for spawn sound");
        yield return new WaitForSeconds (spawnDelay);

        Instantiate (playerPrefab, spawnPoint.position, spawnPoint.rotation);
        Debug.Log ("TODO: Add Spawn Particles");
    }
    public static void KILLPLAYER (){ //GameObject player
        Destroy (GameObject.FindGameObjectWithTag("Player"));
        gm.StartCoroutine(gm.RespawnPlayer());
    }
}
