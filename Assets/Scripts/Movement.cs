using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Movement : MonoBehaviour
{
    public GameObject boat;
    public Rigidbody body;
    public float speed = .3f;
    public float turnSpeed = .02f;
    public float range = 5;
    public GameObject sailUp;
    public GameObject sailDown;
    public GameObject oarsRight;
    public GameObject oarsLeft;
    enum BoatState
    {
        Oars,
        Sail
    }
    BoatState boatState;

    [SerializeField]
    private Lap lapScript; 

    [SerializeField]
    public Canvas gameOverScreen; 

    private void Start()
    {
        boatState = BoatState.Oars;
        sailUp.SetActive(true);
        sailDown.SetActive(false);
    }
    private void Update()
    {
        if (boatState == BoatState.Oars)
        {
            sailUp.SetActive(true);
            sailDown.SetActive(false);
            oarsLeft.SetActive(true);
            oarsRight.SetActive(true);
            speed = .3f;
        }
        else if (boatState == BoatState.Sail)
        {
            sailUp.SetActive(false);
            sailDown.SetActive(true);
            oarsLeft.SetActive(false);
            oarsRight.SetActive(false);
            speed = 1f;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (boatState == BoatState.Oars)
                boatState = BoatState.Sail;
            else if (boatState == BoatState.Sail)
                boatState = BoatState.Oars;
        }

        if (Input.GetKey(KeyCode.A))//A = rotate left
            body.AddTorque(transform.up * -turnSpeed, ForceMode.Force);
        if (Input.GetKey(KeyCode.D))//D = rotate right
            body.AddTorque(transform.up * turnSpeed, ForceMode.Force);
        if (Input.GetKey(KeyCode.W))//W = forward
            body.AddRelativeForce(Vector3.forward * speed, ForceMode.Force);
        if (Input.GetKey(KeyCode.S))//S = go backwards
            body.AddRelativeForce(Vector3.back * speed, ForceMode.Force);

        if (lapScript.GetLapCount() >= 4)
        {
            gameOverScreen.GetComponent<GameOverScreen>().Setup(lapScript.GetFastestTime());
        }
    }
}
