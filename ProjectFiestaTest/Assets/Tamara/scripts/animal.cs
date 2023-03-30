using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animal : MonoBehaviour
{

    [SerializeField] int id;
    [SerializeField] float speed;
    [SerializeField] GameObject skin;
     bool isMoving;


    public void Initialize()
    {
        isMoving = true;
        speed = Random.Range(3,8);
        transform.localPosition = new Vector3(0, 0, 0);
        transform.localRotation = Quaternion.identity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag== "goal")
        {
            Destroy(gameObject);
        }
        
    }


    private void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));

        }
    }
}
