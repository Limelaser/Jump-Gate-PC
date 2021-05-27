using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        // if the game controllerobjecti is found
        if (gameControllerObject != null)
        {
            // sets the gamecontroller to gamecontroller script
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        // if it cannot find the gamecontroller
        if (gameController == null)
        {
            // it tells us in a message
            Debug.Log("Cannot find 'GameController' script ");
        }
    }

    // detects objects entering the trigger
    private void OnTriggerEnter(Collider other)
    {
        // checks if the objects tag is not boundary
        if (other.gameObject.tag != "Boundary")
        {
            // if it isn't boundary then it creates an explosion
            Instantiate(explosion, transform.position, transform.rotation);
            
            // checks that the object it collides with has the tag PlayerBolt
            if (other.gameObject.tag == "PlayerBolt")
            {
                // if it does then it adds to the score
                gameController.AddScore(scoreValue);
            }
            // checks that the object it collides with has the tag Hazard
            else if (other.gameObject.tag != "Hazard")
            {
                // if it is hazard it does nothing
            }
            // checks that the object it collides with has the tag Enemy
            else if (other.gameObject.tag != "Enemy")
            {
                // if it is enemy then it does nothing
            }

            // either way it destroys both objects
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        // checks the object entering the trigger for the player tag
        if (other.gameObject.tag == "Player")
        {
            // if it finds the player tag it creates an explosion and ends the game
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
    }
}
