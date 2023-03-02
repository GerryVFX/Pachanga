using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] TMP_Text avalibleMovesTXT;
    [SerializeField] GameObject finishMoveBTN;
    [SerializeField] Image[] characterSkin;

    public GameObject dice; 
    public GameObject ownDice; 
    public Transform dicePos;
    public MeshRenderer skin;
    public int nDices;
    public int avalibleMoves;
    public int coins;
    public bool endMove;
    //public bool inEvent;

    private void Awake()
    {
        skin.material.color = characterSkin[PlayerManager.Instance.characterIndex].color;
        ownDice = Instantiate(dice).transform.gameObject;
    }
    private void OnEnable()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("event"))
        {
            PlayerManager.Instance.inEvent = true;
        }
    }

    void Update()
    {
        PlayerManager.Instance.playerPosinBoard = transform.position;
        nDices = PlayerManager.Instance.nDice;
        avalibleMoves = PlayerManager.Instance.totalMoves;

        if(PhasesManager.Instance.rollPhase == false)
        {
            ownDice.SetActive(false);
        }
        else
        {
            ownDice.transform.position = dicePos.position;
            ownDice.SetActive(true);
        }
            

        if (PhasesManager.Instance.movePhase)
        {
            avalibleMoves = PlayerManager.Instance.totalMoves;
            avalibleMovesTXT.text = avalibleMoves.ToString();
            avalibleMovesTXT.transform.gameObject.SetActive(true);

            if (avalibleMoves <= 0 && !PlayerManager.Instance.endMove)
            {
                finishMoveBTN.SetActive(true);
            }
            else
                finishMoveBTN.SetActive(false);
        }
        else
            avalibleMovesTXT.transform.gameObject.SetActive(false);
    }

    public void FinishMove()
    {
        finishMoveBTN.SetActive(false);
        PlayerManager.Instance.endMove = true;
    }
}
