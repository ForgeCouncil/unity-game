﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnSceneLoad : MonoBehaviour
{
    void Start()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    void OnDestroy()
    {
        Debug.Log(this.name + " was destroyed. You probably closed the program.");
    }
}