using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject loadingPanel, lobbyPanel;

    public void Conecting()
    {
        loadingPanel.SetActive(true);
        PhotonNetwork.ConnectUsingSettings();
    }


    public override void OnConnectedToMaster()
    {
        loadingPanel.SetActive(false);
        lobbyPanel.SetActive(true);
    }

    public void FindRoom()//Conexión a sala random
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        CreateRoom();
    }

    private void CreateRoom()
    {
        int roomID = Random.Range(1, 5000);
        RoomOptions roomOptions = new RoomOptions()
        {
            IsVisible = true,
            IsOpen = true,
            MaxPlayers = 6,
            PublishUserId = true
        };

        PhotonNetwork.CreateRoom("Room: " + roomID.ToString(), roomOptions);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("RoomGame");
    }
}
