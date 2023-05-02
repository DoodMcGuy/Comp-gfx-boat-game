using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class OneWayCollider : MonoBehaviour
{
    BoxCollider collider;
    
    void Awake(){
        collider = GetComponent<BoxCollider>();
<<<<<<< Updated upstream
        collider.isTrigger = false;

        //set up the collider that will check we're moving in the right direction
        //collider is trigger_scale times larger than the finish line collider
        collisionCheckTrigger = gameObject.AddComponent<BoxCollider>();
        collisionCheckTrigger.size = collider.size * trigger_scale;
        collisionCheckTrigger.center = collider.center;
        collisionCheckTrigger.isTrigger = true;
    }
    
    //in order for collision to detect the boats have to have a rigidbody
    //make sure to freeze their rotation on all axes as of right now because
    //the boat gets shoved out of the actual collider once it's too close to the edge
    void OnTriggerStay(Collider other){

        //checking if another collider (in this case the player) is inside the trigger
        //if it is inside the trigger and going the right direction let it pass through
        //otherwise don't
        if(Physics.ComputePenetration(
            collisionCheckTrigger, transform.position, transform.rotation,
            other, other.transform.position, other.transform.rotation, 
            out Vector3 collisionDirection, out float penetrationDepth)){

                float dot = Vector3.Dot(entry_direction, collisionDirection);

                //dot product is negative if we're going the wrong way so prevent collision
                if(dot < 0){
                    Physics.IgnoreCollision(collider, other, false);
                }else{
                    Physics.IgnoreCollision(collider, other, true);
                }
            }
    }

    //take lap time when player leaves the trigger
    void OnTriggerExit(Collider other){
        Debug.Log("Left trigger!");
=======
        collider.isTrigger = true;
>>>>>>> Stashed changes
    }

    void OnTriggerEnter(Collider other){
        GameObject collidedObject = other.gameObject;
<<<<<<< Updated upstream

        if(collidedObject.tag == "Boat")
            collidedObject.GetComponent<Lap>().LapTime();
=======
        Lap collidedObjectLapScript = null;
        if (collidedObject.tag == "Boat")
            collidedObjectLapScript = collidedObject.GetComponent<Lap>();
        else
            return; 

        if(collidedObjectLapScript.getLapFlag() == true)
            collidedObjectLapScript.LapTime();

>>>>>>> Stashed changes
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
