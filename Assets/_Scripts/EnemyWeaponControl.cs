using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponControl : MonoBehaviour
{
    public new AudioSource audio;
    public Transform shotSpawn1;
    public Transform shotSpawn2;
    public GameObject shot;
    public float fireRate;
    public float delay;

    private void Start()
    {
        // stets fire to be called upon repeatedly
        InvokeRepeating("Fire", delay, fireRate);
    }

    void Fire()
    {
        // spawns in the laser bolts and plays the audio effect
        Instantiate(shot, shotSpawn1.position, shotSpawn1.rotation);
        Instantiate(shot, shotSpawn2.position, shotSpawn2.rotation);
        audio.Play();
    }
}
