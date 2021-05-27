using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBolt : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;

    // blows up objects without adding to the score
    private void OnTriggerEnter(Collider other)
    {
        // if the object that this script is attatched to collides with an object holding the tag Hazard
        if (other.gameObject.tag == "Hazard")
        {
            // creates an explosion and destroys both objects
            Instantiate(explosion, other.transform.position, other.transform.rotation
                );
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        // if the object that this script is attatched to collides with an object holding the tag player
        if (other.gameObject.tag == "Player")
        {
            // creates an explosion and destroys both objects
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
