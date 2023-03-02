using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

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

    //Variables uso en Creación de personaje
    [Header("Uso en Creación de Personaje")]
    public string playerName;
    public int characterIndex;

    //Variables uso en BoardScene
    [Header("Uso en BoardScene")]
    [SerializeField] GameObject playerPrefab;
    public int playerOrder;
    public Vector3 playerPosinBoard;
    public Vector3 playerPosinMinigame;
    public int nDice;
    public int totalMoves;
    public bool endMove;
    public bool inEvent;
    public int coins;
    public int winPoints;
    public bool winGame;

    //Variables uso en MinijJuego
    [Header("Uso en MinigameScene")]
    public bool winMinigame;

    private void Update()
    {

        if (GameManager.Instance.inBoard)
        {
            if (GameManager.Instance.startInBoard)
            {
                Instantiate(playerPrefab, playerPosinBoard, Quaternion.identity);
                PhasesManager.Instance.players.Add(playerPrefab);
                GameManager.Instance.startInBoard = false;
            }
        }

        if (GameManager.Instance.inMinigame)
        {
            if (GameManager.Instance.startMinigame)
            {
                Instantiate(playerPrefab, playerPosinMinigame, Quaternion.identity);
                GameManager.Instance.startInBoard = false;
            }
        }
    }

}
