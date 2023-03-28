using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlataform : MonoBehaviour
{
    public bool starGame;
    public float timeOff;
    MeshRenderer mesh;
     
    void Start()
    {
        mesh = GetComponentInChildren<MeshRenderer>();
    }

    void Update()
    {
        Vector3 rotationX = new Vector3(transform.rotation.x - 90, transform.rotation.y, transform.rotation.z);

        if (starGame)
        {
            timeOff -= Time.deltaTime;
            mesh.material.color = Color.red;
            if(timeOff <= 0)
            {
                starGame = false;
                
                transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(rotationX), 1f);
            }
        }
        else
        {

            if(timeOff < 2)
            {
                timeOff += Time.deltaTime;
                if (timeOff >= 2)
                {
                    mesh.material.color = Color.gray;
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), 2f);
                }
            }
            
        }
    }
}
