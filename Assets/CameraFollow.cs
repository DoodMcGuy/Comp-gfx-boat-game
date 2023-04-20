using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float posControl = .02f;
    public float rotControl = .01f;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, posControl);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, rotControl);
    }
}
