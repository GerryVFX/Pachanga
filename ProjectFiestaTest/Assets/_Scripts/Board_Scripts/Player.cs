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
    public int coins;
    public bool endMove;

    private void Awake()
    {
        skin.material.color = characterSkin[PlayerManager.Instance.characterIndex].color;
        ownDice = Instantiate(dice).transform.gameObject;
    }

    private void Update()
    {
        if(PhasesManager.Instance.currentPhase == Phases.Roll)
        {
            ownDice.transform.position = dicePos.position;
            ownDice.SetActive(true);
        }
        else
        {
            ownDice.SetActive(false);
        }

        if (PhasesManager.Instance.currentPhase == Phases.Move)
        {
            avalibleMovesTXT.text = PlayerManager.Instance.totalMoves.ToString();
            avalibleMovesTXT.transform.gameObject.SetActive(true);

            if (PlayerManager.Instance.totalMoves <= 0 && !PlayerManager.Instance.endMove)
            {
                finishMoveBTN.SetActive(true);
            }
            else
            {
                finishMoveBTN.SetActive(false);
            }
        }
        else
        {
            avalibleMovesTXT.transform.gameObject.SetActive(false);
        } 
    }

    public void FinishMove()
    {
        finishMoveBTN.SetActive(false);
        PlayerManager.Instance.playerPosInBoard = transform.position;
        PlayerManager.Instance.endMove = true;
        
        PhasesManager.Instance.currentPhase = Phases.None;
    }
}
