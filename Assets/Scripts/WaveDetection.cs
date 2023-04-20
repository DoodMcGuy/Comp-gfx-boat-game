using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveDetection : MonoBehaviour
{
    public static WaveDetection inst;

    public float amp = 1f;
    public float length = 2f;
    public float speed = 1f;
    public float offset = 0f;

    private void Awake()
    {
        if (inst == null)
        {
            inst = this;
        }
        else if (inst != this)
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        offset += Time.deltaTime * speed;
    }

    public float WaveHeight(float i)
    {
        return amp * Mathf.Sin(i / length + offset) * Mathf.Sin(i / length + 2);
    }
}
