using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class Waves : MonoBehaviour
{
    private MeshFilter mf;

    private void Awake()
    {
        mf = GetComponent<MeshFilter>();
    }

    private void Update()
    {
        Vector3[] v = mf.mesh.vertices;
        for (int i = 0; i < v.Length; i++)
        {
            v[i].y = WaveDetection.inst.WaveHeight(transform.position.x + v[i].x);
        }

        mf.mesh.vertices = v;
        mf.mesh.RecalculateNormals();
    }
}
