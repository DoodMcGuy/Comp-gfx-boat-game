using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.activeInHierarchy && gameObject != null)
            Destroy(gameObject, 10f);
    }

}
