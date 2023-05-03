using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLineFlag : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        GameObject collidedObject = other.gameObject;
        Lap collidedObjectScript = null;

        if (collidedObject.tag == "Boat")
            collidedObjectScript = collidedObject.GetComponent<Lap>();
        else
            return;

        if (collidedObjectScript.getLapFlag() == false)
            collidedObjectScript.switchLapFlag();
    }
}