using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flappy_AdminObject : MonoBehaviour
{
    [SerializeField] Transform[] spawnPositions;
    [SerializeField] GameObject coin;

    private void Start()
    {
        InvokeRepeating("SpawnCoins", 3f, 2f);    
    }

    void SpawnCoins()
    {
        Instantiate(coin, spawnPositions[Random.Range(0, spawnPositions.Length)].position, coin.transform.rotation);
    }
}
