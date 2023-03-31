using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static Timer Instance;

    [SerializeField] TMP_Text startTimer;
    [SerializeField] TMP_Text timerText;

    public bool startGame;
    [SerializeField] float timeElapsed;
    int minutes, seconds;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(gameObject);

    }
    void Start()
    {
        StartCoroutine(StartTimer());
    }

    void Update()
    {
        if (startGame)
        {
            timeElapsed -= Time.deltaTime;
            minutes = (int)(timeElapsed / 60f);
            seconds = (int)(timeElapsed - minutes * 60);

            timerText.text = string.Format("{0}:{1}", minutes, seconds);
        }

        if(timeElapsed <= 0)
        {
            startGame = false;
        }
    }

    IEnumerator StartTimer()
    {
        startTimer.text = "3";
        yield return new WaitForSeconds(1f);
        startTimer.text = "2";
        yield return new WaitForSeconds(1f);
        startTimer.text = "1";
        yield return new WaitForSeconds(1f);
        startTimer.text = "Start";
        yield return new WaitForSeconds(0.5f);
        startTimer.gameObject.SetActive(false);
        startGame = true;
    } 
}
