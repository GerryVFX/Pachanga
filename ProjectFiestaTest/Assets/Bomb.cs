using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Color currentColor;
    [SerializeField] BombController bombController;

    // Start is called before the first frame update
    void Start()
    {
        bombController = FindObjectOfType<BombController>();
        currentColor = GetComponent<MeshRenderer>().material.color;
    }

    
    void Update()
    {
        if (bombController.explode==true)
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}
