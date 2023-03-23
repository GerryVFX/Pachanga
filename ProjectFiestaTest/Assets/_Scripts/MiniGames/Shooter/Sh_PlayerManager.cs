using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Sh_PlayerManager : MonoBehaviour
{
    PhotonView pv;

    private void Awake()
    {
        pv = GetComponent<PhotonView>();
    }

    void Start()
    {
        if (pv.IsMine) CreateControll();
    }

    void CreateControll()
    {
        switch (PlayerSettings.Instance.characterID)
        {
            case 0:
                PhotonNetwork.Instantiate(Path.Combine("ShooterPB", "Player00"), Vector3.zero, Quaternion.identity);
                break;
            case 1:
                PhotonNetwork.Instantiate(Path.Combine("ShooterPB", "Player01"), Vector3.zero, Quaternion.identity);
                break;
            case 2:
                PhotonNetwork.Instantiate(Path.Combine("ShooterPB", "Player02"), Vector3.zero, Quaternion.identity);
                break;
            case 3:
                PhotonNetwork.Instantiate(Path.Combine("ShooterPB", "Player03"), Vector3.zero, Quaternion.identity);
                break;
            case 4:
                PhotonNetwork.Instantiate(Path.Combine("ShooterPB", "Player04"), Vector3.zero, Quaternion.identity);
                break;
            case 5:
                PhotonNetwork.Instantiate(Path.Combine("ShooterPB", "Player05"), Vector3.zero, Quaternion.identity);
                break;
            case 6:
                PhotonNetwork.Instantiate(Path.Combine("ShooterPB", "Player06"), Vector3.zero, Quaternion.identity);
                break;
        }
    }
}
