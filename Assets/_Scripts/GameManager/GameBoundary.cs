using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoundary : MonoBehaviour
{
    // detects when game objects leave a collider
    private void OnTriggerExit(Collider other)
    {
        // Destroys objects when they leave the collider 
        Destroy(gameObject);
    }
}
