using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public GameObject boat;
    private Rigidbody body;
    private float rotation = .14f; //will determine how strong angle of rotation is
    public float range = 5;
    [SerializeField]
    private Lap lapScript;

    [SerializeField]
    public Canvas gameOverScreen;

    // Update is called once per frame
    void Update(){
        
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward * range));

        if(Input.GetKey(KeyCode.A))//A = rotate left
            boat.transform.Rotate(0.0f, -rotation, 0.0f);
        if(Input.GetKey(KeyCode.D))//D = rotate right
            boat.transform.Rotate(0.0f, rotation, 0.0f);
        if(Input.GetKey(KeyCode.W))//W = forward
            boat.transform.Translate(Vector3.forward * (Time.deltaTime * 2));
        if(Input.GetKey(KeyCode.S))//S = go backwards
            boat.transform.Translate(Vector3.back * (Time.deltaTime * 2));
        
        if (lapScript.GetLapCount() >=4){
            gameOverScreen.GetComponent<GameOverScreen>().Setup(lapScript.GetFastestTime());
        }
    }
}
