using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GorundCheck : MonoBehaviour
{
    public bool grounded;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            grounded = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            grounded = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            grounded = true;
        }
    }
}
