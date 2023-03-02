using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameConfig : MonoBehaviour
{
    [SerializeField] TMP_Text nroundText;
    [SerializeField] MeshRenderer playerExample;
    [SerializeField] PlayerManager playerManager;

    public int nRound = 5; 

    public Image[] colorSelection;
    int playerIndex;

    private void Start()
    {
        playerExample.material.color = colorSelection[0].color;
    }

    private void Update()
    {
        nroundText.text = nRound.ToString();
        PlayerManager.Instance.characterIndex = playerIndex;
        GameManager.Instance.nRound = nRound;
    }

    private void OnEnable()
    {
        GameManager.Instance.inSelection = true;
    }

    public void SlectCharacter1()
    {
        playerExample.material.color = colorSelection[0].color;
        playerIndex = 0;
    }
    public void SlectCharacter2()
    {
        playerExample.material.color = colorSelection[1].color;
        playerIndex = 1;
    }
    public void SlectCharacter3()
    {
        playerExample.material.color = colorSelection[2].color;
        playerIndex = 2;
    }
    public void SlectCharacter4()
    {
        playerExample.material.color = colorSelection[3].color;
        playerIndex = 3;
    }
    public void SlectCharacter5()
    {
        playerExample.material.color = colorSelection[4].color;
        playerIndex = 4;
    }
    public void SlectCharacter6()
    {
        playerExample.material.color = colorSelection[5].color;
        playerIndex = 5;
    }

    public void PlusRound()
    {
        if (nRound < 20) nRound += 5;
    }
    public void MinumRound()
    {
        if (nRound > 5) nRound -= 5;
    }

    public void GotoBoard()
    {
        GameManager.Instance.inSelection = false;
        GameManager.Instance.newGame = true;
        SceneManager.LoadScene(1);
    }
}
