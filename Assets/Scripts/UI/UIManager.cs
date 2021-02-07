using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    private static UIManager instance;
    public static UIManager Instance {
        get {
            if (instance == null) {
                throw new System.Exception("Tried to access UIManager.Instance but there are none initialized in the scene.");
            }
            return instance;
        }
        set {
            if (instance != null) {
                throw new System.Exception("Tried to set UIManager.Instance but there is already one initialized in the scene.");
            }
            instance = value;
        }
    }

    private bool isPaused = false;

    // public TextMesh

    // Start is called before the first frame update
    void Start() {
        Debug.Log("UIManager.Start :: UI Manager starting up.");
        UIManager.Instance = this;
    }

    // Update is called once per frame
    void Update() {

    }

    public void togglePause() {
        isPaused = !isPaused;
        Debug.Log("UIManager.togglePause :: Setting paused to " + isPaused.ToString());
    }

}
