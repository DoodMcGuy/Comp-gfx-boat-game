using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject boat;
    public Rigidbody body;
    public float speed = 5f;
    public float turnSpeed = 1f;
    public float range = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(Input.GetKey(KeyCode.A))//A = rotate left
            body.AddTorque(transform.up * -turnSpeed, ForceMode.Force);
        if (Input.GetKey(KeyCode.D))//D = rotate right
            body.AddTorque(transform.up * turnSpeed, ForceMode.Force);
        if (Input.GetKey(KeyCode.W))//W = forward
            body.AddRelativeForce(Vector3.forward * speed,ForceMode.Force);
        if(Input.GetKey(KeyCode.S))//S = go backwards
            body.AddRelativeForce(Vector3.back * speed, ForceMode.Force);

    }
}
