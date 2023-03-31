using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_DangerZoneMove : MonoBehaviour
{
    public bool startGame;
    float movingUp;
    
    void Start()
    {
        movingUp = -16;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Player"))
        //{
        //    Destroy(other.gameObject);
        //}
    }
    void Update()
    {
        if (Timer.Instance.startGame) movingUp += Time.deltaTime;

        if (movingUp < 13)
        {
            transform.position = new Vector3(transform.position.x, movingUp, transform.position.z);
        }
    }
        
}
