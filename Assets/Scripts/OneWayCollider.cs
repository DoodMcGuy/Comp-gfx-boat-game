using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class OneWayCollider : MonoBehaviour
{
    BoxCollider collider;
    
    void Awake(){
        collider = GetComponent<BoxCollider>();
        collider.isTrigger = true;
    }
    

    void OnTriggerEnter(Collider other){
        GameObject collidedObject = other.gameObject;

        if(collidedObject.tag == "Boat")
            collidedObject.GetComponent<Lap>().LapTime();

        Lap collidedObjectLapScript = null;
        if (collidedObject.tag == "Boat")
            collidedObjectLapScript = collidedObject.GetComponent<Lap>();
        else
            return; 

        if(collidedObjectLapScript.getLapFlag() == true)
            collidedObjectLapScript.LapTime();

    }

    void OnTrigerStay(Collider other){
        GameObject collidedObject = other.gameObject;
        Lap collidedObjectLapScript = null;
        if (collidedObject.tag == "Boat")
            collidedObjectLapScript = collidedObject.GetComponent<Lap>();
        else
            return; 

        if(collidedObjectLapScript.getLapFlag() == true)
            Physics.IgnoreCollision(collider, other, true);

    }

    void OnTriggerExit(Collider other){
        GameObject collidedObject = other.gameObject;
        Lap collidedObjectLapScript = null;
        if (collidedObject.tag == "Boat")
            collidedObjectLapScript = collidedObject.GetComponent<Lap>();
        else
            return;
        
        if(collidedObjectLapScript.getLapFlag() == true)
            collidedObjectLapScript.switchLapFlag();
    }
}
