using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine;
using System.Collections;

 public class Rotata : MonoBehaviour
{
    public Transform target;


    void Update()
    {
        Vector3 relativePos = (target.position + new Vector3(0, 5f, 0)) - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);

        Quaternion current = transform.localRotation;

        transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);
        transform.Translate(0, 0, 5 * Time.deltaTime);
    }
}
