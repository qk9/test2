using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour // this class tells objects affected by gravity to get sucked towards gravity wells at the right times
{
    public CircleCollider2D coll2D;
    public float gravityPower;
    public float scalingThreshold;
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("Collisions are here!");
    }

    void OnTriggerStay2D(Collider2D collider) // this gets called once per frame for each object that is in contact with coll2D
    {
        if(collider.gameObject.tag == "Player") // if the current thing inside coll2D is the player
        {
            float gravDepthPercent = ((Mathf.Abs(Vector2.Distance(collider.gameObject.transform.position, coll2D.transform.position)) - (coll2D.radius * coll2D.transform.localScale.x))
                / (coll2D.radius * coll2D.transform.localScale.x)); // calculate distance of gravwell entrant to center of gravwell relative to gravwell's size
            //Debug.Log(gravDepthPercent);
            if(Mathf.Abs(gravDepthPercent) < scalingThreshold)
            {
                gravDepthPercent = scalingThreshold * -1;
            }
            float force = gravDepthPercent * gravityPower; // calculate pull force
            //Debug.Log(force);
            Vector2 attractPoint = coll2D.transform.position; // store gravity well's position
            GravPackage pack = new GravPackage(force, attractPoint); // package up this data
            collider.gameObject.SendMessage("Attract", pack); // send relevant data from the gravity well to the player to be dealt with by GravityApplier
        }
    }
}
