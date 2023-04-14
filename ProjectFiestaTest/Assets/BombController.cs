using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public bool isActive;
    public bool explode;

    public int nExplode;
    public int nSwitch;

    private void Update()
    {
        if (isActive)
        {
            nExplode = Random.Range(1, 3);
        }

        if(nSwitch == nExplode)
        {
            explode = true;
        }
    }
}
