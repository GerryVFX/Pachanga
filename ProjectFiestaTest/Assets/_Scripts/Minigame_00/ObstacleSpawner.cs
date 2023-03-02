using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstacle;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateObstacles", 2, 3.5f);
    }

    void CreateObstacles()
    {
        Instantiate(obstacle, transform.position, transform.rotation);
    }
}
