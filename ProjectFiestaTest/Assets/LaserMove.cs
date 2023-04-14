using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMove : MonoBehaviour
{
    public float speed;

    void Update()
    {


        transform.Translate(Vector3.back * speed * Time.deltaTime);

        if (transform.position.z < -3) Destroy(gameObject);
    }
}
