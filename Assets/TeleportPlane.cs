using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlane : MonoBehaviour {

    public GameObject destination;

    void OnTriggerEnter(Collider obj) {
        Debug.Log("TeleportPlane.OnTriggerEnter :: Triggered by collider", obj);

        if (obj.tag == "Player") {
            Debug.Log("TeleportPlane.OnTriggerEnter :: Player detected");
            CharacterController controller = obj.GetComponent("CharacterController") as CharacterController;
            controller.GetComponent<playerMove>().Teleport(destination.transform.position);

        } else {
            Debug.Log("TeleportPlane.OnTriggerEnter :: Non-player object detected");
            obj.transform.position = destination.transform.position;
        }
    }
}
