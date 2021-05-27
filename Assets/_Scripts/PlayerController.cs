using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;

    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform[] shotSpawns;
    public float fireRate;
    public AudioSource audioSource;

    private float nextFire;

    private void Update()
    {
        // checks to see if a button is clicked and a certain period of time has passed
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            
            nextFire = Time.time + fireRate;
            foreach (var shotSpawn in shotSpawns)
            {
                // spawns our laser bolts
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            }
            // plays attatched audio clip
            audioSource.Play();
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        // creates floats and sets their value to keybindings
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // sets the movement along the x and z values to the keyboard
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        // locks how far the player can move along the x and z axis
        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );
        // set the rotation on the x axis to the value of the speed of movement on the x axis
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}
