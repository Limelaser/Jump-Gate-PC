using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSiseZ;

    private Vector3 startPosition;

    private void Start()
    {
        // sets the start position to the current position
        startPosition = transform.position;
    }

    private void Update()
    {
        // scrolls the backgrount and controlls how fast it scrolls and controlls the backgrounds size on the z value
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSiseZ);
        transform.position = startPosition + Vector3.forward * newPosition;
    }
}
