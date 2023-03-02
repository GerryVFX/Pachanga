using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GeneralInfo : MonoBehaviour
{
    [SerializeField] TMP_Text roundsTXT;
    [SerializeField] TMP_Text phasesTXT;

    [SerializeField] GameObject startBTN;
    [SerializeField] GameObject endTurnBTN;

    void Update()
    {
        roundsTXT.text = "Ronda: " + PhasesManager.Instance.nRounds.ToString();
        if (PhasesManager.Instance.startTurn == false) phasesTXT.text = "Start Round";
        if (PhasesManager.Instance.rollPhase) phasesTXT.text = "Roll Phase";
        if (PhasesManager.Instance.movePhase) phasesTXT.text = "Move Phase";
        if (PhasesManager.Instance.eventPhase) phasesTXT.text = "Event Phase";
        if (PhasesManager.Instance.endTurn)
        {
            phasesTXT.text = "EndTurn";
            endTurnBTN.SetActive(true);
        }
        else
        {
            endTurnBTN.SetActive(false);
        }

        if (PhasesManager.Instance.startTurn) startBTN.SetActive(false);
        if (PhasesManager.Instance.readyToStart) startBTN.SetActive(true);
    }
}
