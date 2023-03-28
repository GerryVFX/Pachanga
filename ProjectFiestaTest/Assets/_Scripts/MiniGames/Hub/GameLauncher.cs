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
}
