using UnityEngine;

public class facePlayer : MonoBehaviour
{
    public void Update()
    {
        this.transform.LookAt(GameObject.FindWithTag("Player").transform);
    }
}
