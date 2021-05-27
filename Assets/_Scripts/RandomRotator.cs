using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    // creates adjustable float
    public float tumble;
    // sets rb to refer to rigidbody
    Rigidbody rb;

    private void Start()
    {
        // gets the objects rigidbody
        rb = GetComponent<Rigidbody>();
        // sets the object to randomly rotate at the speed of the tumble float
        rb.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
