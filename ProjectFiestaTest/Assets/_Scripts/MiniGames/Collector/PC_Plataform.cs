using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Plataform : MonoBehaviour
{
    public bool rigth;
    public bool left;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rigth"))
        {
            rigth = true;
            left = false;
        }
        else if (other.CompareTag("Left"))
        {
            rigth = false;
            left = true;
        }
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }


    void Update()
    {
        if (rigth)
        {
            transform.position = new Vector3(transform.position.x + Time.deltaTime, transform.position.y, transform.position.z);
        }
        else if (left)
        {
            transform.position = new Vector3(transform.position.x - Time.deltaTime, transform.position.y, transform.position.z);
        }
    }
}
