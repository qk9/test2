using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour // this class handles movement inputs from the player
{
    public Rigidbody2D rb2D;
    public float turnSpeed;
    public float enginePower;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Movement is here!");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) // accelerate forward
        {
            Vector2 forwardSpeed;
            forwardSpeed.x = Mathf.Cos(Mathf.Deg2Rad * rb2D.rotation) * enginePower;
            forwardSpeed.y = Mathf.Sin(Mathf.Deg2Rad * rb2D.rotation) * enginePower;
            rb2D.AddForce(forwardSpeed); // addForce computes f=ma, acting on the rigidbody i set up in unity and using the 2D vector i just created above
        }

        if(Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W)) // accelerate backward
        {
            Vector2 backSpeed;
            backSpeed.x = Mathf.Cos(Mathf.Deg2Rad * rb2D.rotation) * enginePower * -1;
            backSpeed.y = Mathf.Sin(Mathf.Deg2Rad * rb2D.rotation) * enginePower * -1;
            rb2D.AddForce(backSpeed);
        }

        if(Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) // fire left turning thrusters
        {
            rb2D.AddTorque(1f * turnSpeed);
        }

        if(Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)) // fire right turning thrusters
        {
            rb2D.AddTorque(-1f * turnSpeed);
        }

        if (Input.GetKey(KeyCode.Space)) // hold this to reduce turning speed to 0 over time, can rebuild this with custom physics but i'm just using unity's tools atm b/c laziness
        {
            rb2D.angularDrag = 1.5f;
        }
        else // reset the angular drag to preserve momentum when i don't want to stabilize
        {
            rb2D.angularDrag = 0;
        }
    }
}
