using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Enemy : MonoBehaviour
{
    public bool positive;
    public bool negative;
    
    void Start()
    {
        positive = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            if (positive)
            {
                positive = false;
                negative = true;
            }

            else if (negative)
            {
                negative = false;
                positive = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag("Player"))
        //{
        //    Destroy(collision.gameObject);
        //}
    }

    void Update()
    {
        if (positive)
        {
            transform.position = new Vector3(transform.position.x + Time.deltaTime, transform.position.y, transform.position.z);
        }
        else if (negative)
        {
            transform.position = new Vector3(transform.position.x - Time.deltaTime, transform.position.y, transform.position.z);
        }
    }
}
