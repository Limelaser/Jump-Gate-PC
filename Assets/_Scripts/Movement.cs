using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;

    // creats a customizable float to adjust the speed of the object
    public float speed;

    // sets the objects motion to begin at the start of the game or when the object spawns
    private void Start()
    {
        // uses the rigidbody to move the object in a direction at the speed of our float
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }
}
