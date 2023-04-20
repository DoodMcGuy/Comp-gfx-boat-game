using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class OneWayCollider : MonoBehaviour
{
    BoxCollider collider;
    float trigger_scale = 1.5f;
    BoxCollider collisionCheckTrigger;

    //direction that the external collider is supposed to be entering from
    //makes this element reusable 
    [SerializeField]Vector3 entry_direction = new Vector3(-1.0f, 0.0f, 0.0f);
    
    void Awake(){
        collider = GetComponent<BoxCollider>();
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
    }

    void OnTriggerEnter(Collider other){
        GameObject collidedObject = other.gameObject;

        if(collidedObject.tag == "Boat")
            collidedObject.GetComponent<Lap>().LapTime();
    }

    void Update(){
        Debug.DrawRay(transform.position, transform.TransformDirection(entry_direction * 5.0f));
    }



}
