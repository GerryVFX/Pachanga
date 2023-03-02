using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Escena actual")]
    public bool inSelection;
    public bool inBoard;
    public bool inMinigame;

    [Header("Información de juego")]
    public int nRound;
    public bool newGame;
    public bool endRound;
    public bool startInBoard;
    public bool startMinigame;
    public int pointsToWin;
    public string playerWin;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    void Update()
    {
        //Estado de Escena

        if (inSelection)
        {
            inBoard = false;
            inMinigame = false;
        }
        if (inBoard)
        {
            inSelection = false;
            inMinigame = false;
        }
        if (inMinigame)
        {
            inBoard = false;
            inSelection = false;
        }
    }
}
