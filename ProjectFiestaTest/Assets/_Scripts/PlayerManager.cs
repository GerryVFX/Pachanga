using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    
    //Variables uso en Creacion de personaje
    [Header("Uso en Creacion de Personaje")]
    public string playerName;
    public int characterIndex;

    //Variables uso en BoardScene
    [Header("Uso en BoardScene")]
    [SerializeField] GameObject playerPrefab;
    public int playerOrder;
    public Vector3 playerPosInBoard;
    public Vector3 playerPosinMinigame;
    public int nDice;
    public int totalMoves;
    public bool endMove = false;
    public bool inEvent;
    public int coins;
    public int winPoints;
    public bool winGame;

    //Variables uso en MinijJuego
    [Header("Uso en MinigameScene")]
    public bool winMinigame;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        GameManager.Instance.SceneChanged += OnSceneChanged;
    }

    private void OnDestroy()
    {
        GameManager.Instance.SceneChanged -= OnSceneChanged;
    }

    private void OnSceneChanged(SceneType sceneType)
    {
        switch (sceneType)
        {
            case SceneType.Selection:
                break;
            case SceneType.Board:
                Instantiate(playerPrefab, playerPosInBoard, Quaternion.identity);
                PhasesManager.Instance.players.Add(playerPrefab);
                break;
            case SceneType.MiniGame:
                //Instantiate(playerPrefab, playerPosinMinigame, Quaternion.identity);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

}
