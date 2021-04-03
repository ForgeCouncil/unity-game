using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {

    public enum SceneTarget {
        [EnumMember(Value = "First Area")]
        FirstArea,
        [EnumMember(Value = "Duncan Scene")]
        Duncan,
        [EnumMember(Value = "Swamp")]
        Swamp,
        [EnumMember(Value = "FloatingIslands")]
        FloatingIslands,
        [EnumMember(Value = "PortalRoom")]
        PortalRoom,
        [EnumMember(Value = "Tundra")]
        Tundra,
        [EnumMember(Value = "Darkness")]
        Darkness,
    }

    public SceneTarget portalTarget;

    void Start() {
        // handle 
        SceneManager.activeSceneChanged += OnSceneLoaded;
    }

    void OnTriggerEnter(Collider player) {
        Debug.Log("SceneSwitch.OnTriggerEnter :: Triggered by collider", player);

        if (player.tag == "Player") {
            Debug.Log("SceneSwitch.OnTriggerEnter :: Player detected");
            CharacterController controller = player.GetComponent("CharacterController") as CharacterController;

            Debug.Log("SceneSwitch.OnTriggerEnter :: Current scene index: " + SceneManager.GetActiveScene().buildIndex);


            // start loading the target scene
            Debug.Log("SceneSwitch.OnTriggerEnter :: Target scene: " + portalTarget.ToString());

            SceneManager.LoadScene(portalTarget.ToString());
        }
    }

    public void OnSceneLoaded(Scene oldScene, Scene newScene) {
        Debug.Log("SceneSwitch.OnTriggerEnter :: New scene index: " + SceneManager.GetActiveScene().buildIndex);

        GameObject[] anchors = GameObject.FindGameObjectsWithTag("Start Anchor");

        if (anchors.Length > 0) {
            GameObject anchor = anchors[0];
            Debug.Log("SceneSwitch.OnTriggerEnter :: Start Anchor", anchor);
            GameObject.FindGameObjectWithTag("Player").GetComponent<playerMove>().Teleport(anchor.transform.position);
        }
    }

}
