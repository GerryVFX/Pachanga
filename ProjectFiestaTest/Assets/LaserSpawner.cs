using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] laser;

    void Start()
    {
        InvokeRepeating("SpawnLasers", 3f, 4);
    }

    void SpawnLasers()
    {
        Instantiate(laser[Random.Range(0, laser.Length)], transform.position, Quaternion.identity);
    }
}
