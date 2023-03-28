using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfomManager : MonoBehaviour
{
    [SerializeField] FallPlataform[] plataforms;
    public float timeOff;
    public Timer startGame;
    public bool fallPlataform;
    
    void Start()
    {
        InvokeRepeating("FallPlataforms", 5f, 0.5f);
    }

    void FallPlataforms()
    {
        if (startGame.startGame)
        {
            plataforms[Random.Range(0, plataforms.Length)].GetComponent<FallPlataform>().starGame = true;
        }
    }
}
