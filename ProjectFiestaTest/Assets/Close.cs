using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Close : MonoBehaviour
{
    public static Close Instance;

    [SerializeField] CanvasGroup score;
    [SerializeField] GameObject finishPanel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(gameObject);
    }

    public void OpenPanel()
    {
        score.alpha = 1;
        finishPanel.SetActive(true);
    }

    public void LeaveGame()
    {
        //if (PhotonNetwork.InRoom)
        //{
        //    PhotonNetwork.CloseConnection(PhotonNetwork.LocalPlayer);
        //}
        
        //PhotonNetwork.LoadLevel(0);
    }
}
