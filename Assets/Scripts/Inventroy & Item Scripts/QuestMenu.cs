using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMenu: MonoBehaviour
{

#region Singleton

    public static QuestMenu instance;

    void Awake ()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Quest Menu found!");
            return;
        }

        instance = this;
    }
    
    #endregion
    

    // Start is called before the first fram update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}