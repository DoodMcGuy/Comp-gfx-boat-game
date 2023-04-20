using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    public Rigidbody rb;
    public float depthSubmerged = 1f;
    public float displacement = 3f;
    public int floatCount = 1;
    public float waterDrag = 0.99f;
    public float waterAngDrag = 0.5f;

    private void FixedUpdate()
    {
        rb.AddForceAtPosition(Physics.gravity / floatCount, transform.position, ForceMode.Acceleration);

        float waveHeight = WaveDetection.inst.WaveHeight(transform.position.x);
        if (transform.position.y < waveHeight)
        {
            float displacementMultiplier = Mathf.Clamp01((waveHeight - transform.position.y) / depthSubmerged) * displacement;
            rb.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), transform.position, ForceMode.Acceleration);
            rb.AddForce(displacementMultiplier * -rb.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            rb.AddTorque(displacementMultiplier * -rb.angularVelocity * waterAngDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }
}
