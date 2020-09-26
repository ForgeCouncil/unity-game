using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnSceneLoad : MonoBehaviour
{
    //Making objects with this script attached into singletons.
    static DontDestroyOnSceneLoad Single;

    void Start()
    {
        if(Single != null)
        {
            Destroy(this.gameObject);
            return;
        }
        
        //there can only be one
        Single = this;
        //become immortal 
        GameObject.DontDestroyOnLoad(this.gameObject);
        
    }

    void OnDestroy()
    {
        Debug.Log(this.name + " was destroyed. You probably closed the program.");
    }
}