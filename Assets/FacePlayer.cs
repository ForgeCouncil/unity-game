using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    public GameObject player;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        this.transform.LookAt(player.transform);
    }
}
