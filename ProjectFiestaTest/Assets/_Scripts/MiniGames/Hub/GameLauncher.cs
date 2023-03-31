using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameLauncher : MonoBehaviour
{
    public void ShooterLauncher()
    {
        PhotonNetwork.LoadLevel("Shooter");
    }
    public void FallPlataformLauncher()
    {
        PhotonNetwork.LoadLevel("PlatformFalls");
    }
    public void Climb()
    {
        PhotonNetwork.LoadLevel("Climb");
    }
    public void Collector()
    {
        PhotonNetwork.LoadLevel("PlataformCollector");
    }
}
