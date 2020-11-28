using UnityEngine;

public class isSticky : MonoBehaviour
{
    public bool sticky;

    void Start()
    {
        sticky = false;
    }

    void Update()
    {
        if (sticky == true)
        {
            Debug.Log("I'm Sticky!");
        }
    }
}