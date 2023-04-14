using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_ActivePad : MonoBehaviour
{

    Color currentColor;
    [SerializeField] BombController bombController;

    // Start is called before the first frame update
    void Start()
    {
        bombController = FindObjectOfType<BombController>();
        currentColor = GetComponent<MeshRenderer>().material.color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bombController.isActive = true;
            GetComponent<MeshRenderer>().material.color = Color.white;
            bombController.nSwitch = int.Parse(gameObject.name);

            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * 2, ForceMode.Force);
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        bombController.isActive = false;
    }

    private void Update()
    {
        if(bombController.isActive == false)
        {
            GetComponent<MeshRenderer>().material.color = currentColor;
        }
    }
}
