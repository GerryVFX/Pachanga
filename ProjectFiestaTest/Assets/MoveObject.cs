using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed;

    void Update()
    {
       

        transform.Translate(Vector3.left * speed * Time.deltaTime); 
        
        if(transform.position.x < -10) Destroy(gameObject);
    }
}
