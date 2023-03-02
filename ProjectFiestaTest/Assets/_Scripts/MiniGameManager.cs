using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    float timer = 60f;
    int min, sec;
    [SerializeField] TMP_Text timeText;

    [SerializeField] bool endMinigame;

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        min = (int)(timer / 60f);
        sec = (int)(timer - min * 60f);
        timeText.text = string.Format("{0}:{1}", min, sec);
    }


    public void BackBoard()
    {
        GameManager.Instance.nRound -= 1;
        GameManager.Instance.endRound = true;
        SceneManager.LoadScene(1);
    }
}
