using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{

    public Vector3 wind_origin;
    public Vector3 wind_val;
    public float timer;
    float counter;
    float speed_counter = 2f;
    public Transform boat;
    public float speed_mod;

    // Start is called before the first frame update
    void Start()
    {
        ChangeWind();
        counter = timer;
    }

    // Update is called once per frame
    void Update()
    {
        counter -= 1 * Time.deltaTime;
        if (counter <= 0f )
        {
            ChangeWind();
            counter = timer;
        }
        speed_counter -= 1 * Time.deltaTime;
        if (speed_counter <= 0f) {
            float angle = Quaternion.Angle(boat.rotation, transform.rotation);
            if (angle <= 80 && angle >= -80)
                speed_mod = Mathf.Abs(Mathf.Cos(angle));
            else
                speed_mod = 0.1f;
            speed_counter = 2f;
        }
    }

    void ChangeWind()
    {
        var randomChange = Random.Range(-180, 180);
        wind_val = Quaternion.AngleAxis(randomChange, Vector3.up) * wind_origin;
        this.transform.rotation = Quaternion.LookRotation(wind_val);
        
    }
}
