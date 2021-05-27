
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDestroy : MonoBehaviour
{
    public float lifeTime;

    private void Start()
    {
        // destroys the attatched object after the lifeTime countdouwn has ended
        Destroy(gameObject, lifeTime);
    }
}
