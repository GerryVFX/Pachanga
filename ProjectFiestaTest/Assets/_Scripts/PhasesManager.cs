using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhasesManager : MonoBehaviour
{
    public static PhasesManager Instance;

    //Control de players
    public List<GameObject> players = new List<GameObject>();
    public int totalPlayers;
    public int currentPlayer;
    [SerializeField] Transform initialPos;

    //Estado de Ronda
    public int nRounds;
    public bool startRound, endRound;
    public bool newGame;

    //Estado de fases
    public bool readyToStart;
    public bool rollPhase, movePhase, eventPhase;
    public bool startTurn, endTurn;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (GameManager.Instance.newGame)
        {
            GameManager.Instance.newGame = false;
            GameManager.Instance.inBoard = true;
            PlayerManager.Instance.playerPosinBoard = initialPos.position; 
        }

        
    }

    private void OnEnable()
    {
        GameManager.Instance.startInBoard = true;
        readyToStart = true;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        nRounds = GameManager.Instance.nRound;

        RoundCicle();
        TurnCicle();

    }

    void RoundCicle()
    {
        if (GameManager.Instance.endRound)
        {
            GameManager.Instance.endRound = false;
            readyToStart = true;
        }
    }

    void TurnCicle()
    {
        if (startTurn)
        {
            StartCoroutine(TurnPlayer());
        }

        if (endTurn)
        {
            startTurn = false;
            StopCoroutine(TurnPlayer());
        }
    }

    //Métodos por boton
    public void StartTurn()
    {
        readyToStart = false;
        startRound = false;
        startTurn = true;
        rollPhase = true;
        PlayerManager.Instance.nDice += 1;
    }

    public void NextRound()
    {
        if ((currentPlayer)+1 < players.Count)
        {
            currentPlayer += 1;
            readyToStart = true;
        }
        else
        {
            endTurn = false;
            SceneManager.LoadScene(2);
        }
    }

    IEnumerator TurnPlayer()
    {
        yield return new WaitUntil(() => !rollPhase);

        if(startTurn && !rollPhase) movePhase = true;

        if(PlayerManager.Instance.endMove == true)
        {
            movePhase = false; 
        }

        yield return new WaitUntil(() => !movePhase);

        if(startTurn && !movePhase) eventPhase = true;

        if (PlayerManager.Instance.inEvent == false)
        {
            eventPhase = false;
        }

        yield return new WaitUntil(() => !eventPhase);
        PlayerManager.Instance.endMove = false;
        endTurn = true;
        yield return null;
    }

}
