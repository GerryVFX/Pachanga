using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{
    [SerializeField] bool itemInRange;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("item"))
        {
            itemInRange = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("item"))
        {
            if (itemInRange)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    other.transform.SetParent(transform);
                    other.transform.position = transform.position;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("item"))
        {
            itemInRange = false;
        }
    }

    private void Update()
    {
        
    }
}
