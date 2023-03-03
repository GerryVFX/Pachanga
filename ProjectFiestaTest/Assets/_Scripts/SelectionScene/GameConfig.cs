using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameConfig : MonoBehaviour
{
    [SerializeField] TMP_Text nroundText;
    [SerializeField] MeshRenderer playerExample;
    [SerializeField] int nRound = 5;
    [SerializeField] Image[] colorSelection;
    int playerIndex;

    private void Awake()
    {
        playerExample.material.color = colorSelection[0].color;
        nroundText.text = nRound.ToString();
    }

    private void Start()
    {
        GameManager.Instance.currentSceneType = SceneType.Selection;
    }

    public void SelectCharacter(int index)
    {
        playerExample.material.color = colorSelection[index].color;
        playerIndex = index;
        PlayerManager.Instance.characterIndex = playerIndex;
    }

    public void PlusRound()
    {
        if (nRound < 20) nRound += 5;
        nroundText.text = nRound.ToString();
    }
    public void SubtractRound()
    {
        if (nRound > 5) nRound -= 5;
        nroundText.text = nRound.ToString();
    }

    public void GotoBoard()
    {
        GameManager.Instance.nRound = nRound;
        GameManager.Instance.newGame = true;
        SceneManager.LoadScene(1);
    }
}
