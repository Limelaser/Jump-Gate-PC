using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evasivemaneuvers : MonoBehaviour
{
    public float dodge;
    public float smoothing;
    public float tilt;
    public Vector2 startWait;
    public Vector2 maneuverTime;
    public Vector2 maneuverWait;
    public Rigidbody rb;
    public Boundary boundary;

    private float currentSpeed;
    private float targetManeuver;

    private void Start()
    {
        // sets currentSpeed to the rigidbody's z axis velocity and starts a coroutine
        currentSpeed = rb.velocity.z;
        StartCoroutine(Evade());
    }

    IEnumerator Evade()
    {
        // waits a random amount of time
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));

        while (true)
        {
            // moves the object a random amount in a random direction on the x axis
            targetManeuver = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);
            // waits a random amount of time
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
            // resets the current value of targetManeuver in preperation for the next dodge
            targetManeuver = 0;
            // waits a random amount of time
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
        }
    }

    private void FixedUpdate()
    {
        // sets our velocity to the target maneuver and sets the speed
        float newManeuver = Mathf.MoveTowards(rb.velocity.x, targetManeuver, Time.deltaTime * smoothing);
        // moves the rigidbody towards the newManeuver and sets the movement on the z axis to currentSpeed in order to keep it moving down the z axis at the same speed
        rb.velocity = new Vector3(newManeuver, 0.0f, currentSpeed);
        // sets the rigidbody position to a new vector 3
        rb.position = new Vector3
            // locks how far the enemy can move on the x and z axis
            (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );
        // rotates the enemy when it moves
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * tilt);
    }
}
