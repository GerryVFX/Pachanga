using System.IO;
using System.Collections;
using System.Linq;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class C_PlayerManager : MonoBehaviour
{
    PhotonView pv;
    GameObject controller;
    [SerializeField]GameObject[] spawnPos;


    private void Awake()
    {
        pv = GetComponent<PhotonView>();
        spawnPos = GameObject.FindGameObjectsWithTag("SpawnPos");
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
                controller = PhotonNetwork.Instantiate(Path.Combine("ClimbPB", "C_Player00"), spawnPos[PlayerSettings.Instance.nPlayer].GetComponent<Transform>().position, Quaternion.identity, 0, new object[] { pv.ViewID });
                break;
            case 1:
                controller = PhotonNetwork.Instantiate(Path.Combine("ClimbPB", "C_Player01"), spawnPos[PlayerSettings.Instance.nPlayer].GetComponent<Transform>().position, Quaternion.identity, 0, new object[] { pv.ViewID });
                break;
            case 2:
                controller = PhotonNetwork.Instantiate(Path.Combine("ClimbPB", "C_Player02"), spawnPos[PlayerSettings.Instance.nPlayer].GetComponent<Transform>().position, Quaternion.identity, 0, new object[] { pv.ViewID });
                break;
            case 3:
                controller = PhotonNetwork.Instantiate(Path.Combine("ClimbPB", "C_Player03"), spawnPos[PlayerSettings.Instance.nPlayer].GetComponent<Transform>().position, Quaternion.identity, 0, new object[] { pv.ViewID });
                break;
            case 4:
                controller = PhotonNetwork.Instantiate(Path.Combine("ClimbPB", "C_Player04"), spawnPos[PlayerSettings.Instance.nPlayer].GetComponent<Transform>().position, Quaternion.identity, 0, new object[] { pv.ViewID });
                break;
            case 5:
                controller = PhotonNetwork.Instantiate(Path.Combine("ClimbPB", "C_Player05"), spawnPos[PlayerSettings.Instance.nPlayer].GetComponent<Transform>().position, Quaternion.identity, 0, new object[] { pv.ViewID });
                break;
            case 6:
                controller = PhotonNetwork.Instantiate(Path.Combine("ClimbPB", "C_Player06"), spawnPos[PlayerSettings.Instance.nPlayer].GetComponent<Transform>().position, Quaternion.identity, 0, new object[] { pv.ViewID });
                break;
        }
    }
}
