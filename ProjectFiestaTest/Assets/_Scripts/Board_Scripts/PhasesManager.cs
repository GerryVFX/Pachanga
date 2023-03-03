using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Phases
{
    Start,
    Roll,
    Move,
    Event,
    End,
    None
}

public delegate void OnPhaseChanged(Phases phase);

public class PhasesManager : MonoBehaviour
{
    public static PhasesManager Instance;
    
    public event OnPhaseChanged PhaseChanged;

    //Control de players
    public List<GameObject> players = new();
    public int currentPlayer;
    [SerializeField] Transform initialPos;

    //Estado de Ronda
    [HideInInspector]public int nRounds;

    //Estado de fases
    public Phases currentPhase;
    private Phases _tempPhase;

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
            PlayerManager.Instance.playerPosInBoard = initialPos.position;
        }
    }

    private void Start()
    {
        GameManager.Instance.currentSceneType = SceneType.Board;
        currentPhase = Phases.Start;
        _tempPhase = currentPhase;
        
        nRounds = GameManager.Instance.nRound;
    }

    private void Update()
    {
        if (_tempPhase != currentPhase)
        {
            PhaseChanged?.Invoke(currentPhase);
            _tempPhase = currentPhase;
        }
        
        RoundCycle();
        TurnCycle();
    }

    private void RoundCycle()
    {
        if (GameManager.Instance.endRound)
        {
            GameManager.Instance.endRound = false;
            currentPhase = Phases.Start;
        }
    }

    private void TurnCycle()
    {
        if (PlayerManager.Instance && currentPhase == Phases.Roll)
        {
            StartCoroutine(TurnPlayer());
        }
    }

    private IEnumerator TurnPlayer()
    {
        yield return new WaitUntil(() => currentPhase != Phases.Roll);
        
        currentPhase = Phases.Move;

        yield return new WaitUntil(() => currentPhase != Phases.Move);

        if (PlayerManager.Instance.inEvent)
        {
            currentPhase = Phases.Event;
        }
        
        yield return new WaitUntil(() => currentPhase != Phases.Event);
        
        currentPhase = Phases.End;

        PlayerManager.Instance.endMove = false;

        yield return null;
    }

    //Metodos por boton
    public void StartTurn()
    {
        PlayerManager.Instance.nDice += 1;
        currentPhase = Phases.Roll;
    }

    public void NextRound()
    {
        if (currentPlayer+1 < players.Count)
        {
            currentPlayer += 1;
            currentPhase = Phases.Start;
        }
        else
        {
            GoToMiniGame();
        }
    }

    private void GoToMiniGame()
    {
        SceneManager.LoadScene(2);
    }

}
