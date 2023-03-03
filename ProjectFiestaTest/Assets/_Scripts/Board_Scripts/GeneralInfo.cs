using System;
using UnityEngine;
using TMPro;

public class GeneralInfo : MonoBehaviour
{
    [SerializeField] TMP_Text roundsTXT;
    [SerializeField] TMP_Text phasesTXT;

    [SerializeField] GameObject startBTN;
    [SerializeField] GameObject endTurnBTN;

    private void Awake()
    {
        PhasesManager.Instance.PhaseChanged += OnPhaseChanged;
    }

    private void Start()
    {
        OnPhaseChanged(PhasesManager.Instance.currentPhase);
    }

    private void OnDestroy()
    {
        PhasesManager.Instance.PhaseChanged -= OnPhaseChanged;
    }
    
    private void OnPhaseChanged(Phases phase)
    {
        roundsTXT.text = "Ronda: " + PhasesManager.Instance.nRounds;
        startBTN.SetActive(PhasesManager.Instance.currentPhase == Phases.Start);
        endTurnBTN.SetActive(PhasesManager.Instance.currentPhase == Phases.End);

        switch (phase)
        {
            case Phases.Start:
                phasesTXT.text = "Start Round";
                break;
            case Phases.Roll:
                phasesTXT.text = "Roll Phase";
                break;
            case Phases.Move:
                phasesTXT.text = "Move Phase";
                break;
            case Phases.Event:
                phasesTXT.text = "Event Phase";
                break;
            case Phases.End:
                phasesTXT.text = "EndTurn";
                break;
            case Phases.None:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
