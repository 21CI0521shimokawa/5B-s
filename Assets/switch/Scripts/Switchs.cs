using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switchs : MonoBehaviour
{
    bool isPush = false;
    void OnCollisionEnter(Collision collision)
    {
        if (isPush) { return; }
        isPush = true;
        GetComponent<MeshRenderer>().material.color = new Color(0, 0, 1, 1);
        Debug.Log("スイッチを押した");
    }
}
