using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityApplier : MonoBehaviour // this class applies the gravity force to an object as directed by GravityController
{
    public Rigidbody2D rb;

    void Attract(GravPackage package) //this method gets called by the SendMessage function in GravityController
    {
        Vector2 gravForce;
        float conversionFactor = package.getPower() / Mathf.Abs(Vector2.Distance(rb.position,package.getPosition()));
        // i want to apply force to my object using a vector2 that points towards the center of the gravity well with a magnitude of getPower.
        // this will create a gravitational pull with its strength determined by the "Gravity Power" field in the Inspector.

        // So to do that, i'll create a conversion factor from getPower, which gets the length of the hypotenuse of the vector2 triangle I want to build,
        // and the distance between me and the center of the gravity well, which is the hypotenuse of the triangle I'm using to set the direction
        // in which the force will be applied.

        // This way, I start with a triangle that shows me the direction I want the force to go,
        // and then I scale that triangle to the correct magnitude.
        gravForce.x = (rb.position.x - package.getPosition().x) * conversionFactor; // set the x component of the gravitational force to be applied
        gravForce.y = (rb.position.y - package.getPosition().y) * conversionFactor; // set the y component of the gravitational force to be applied
        rb.AddForce(gravForce); // apply gravitational force to object
    }
}
