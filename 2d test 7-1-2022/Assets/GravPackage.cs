using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravPackage // this class stores data to be transferred from GravityController to GravityApplier
{
    private float power; // strength of the gravity well
    private Vector2 position; // position towards which the object is being pulled

    public GravPackage() // constructors
    {
        power = 0;
        position = new Vector2(0, 0);
    }
    public GravPackage(float pow)
    {
        power = pow;
        position = new Vector2(0, 0);
    }
    public GravPackage (float pow, Vector2 pos)
    {
        power = pow;
        position = pos;
    }
    public float getPower() // getters and setters
    {
        return power;
    }
    public Vector2 getPosition()
    {
        return position;
    }
    public void setPower(float pow)
    {
        power = pow;
    }
    public void setPosition(Vector2 pos)
    {
        position = pos;
    }
}
