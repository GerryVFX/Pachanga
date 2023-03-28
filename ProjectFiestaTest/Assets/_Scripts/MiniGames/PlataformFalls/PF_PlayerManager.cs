using System.IO;
using System.Collections;
using System.Linq;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class PF_PlayerManager : MonoBehaviour
{
    PhotonView pv;
    GameObject controller;
    GameObject[] spawnPos;


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
                controller = PhotonNetwork.Instantiate(Path.Combine("FallPlataformPB", "PF_Player00"), spawnPos[Random.Range(0, spawnPos.Length)].GetComponent<Transform>().position, Quaternion.identity, 0, new object[] { pv.ViewID });
                break;
            case 1:
                controller = PhotonNetwork.Instantiate(Path.Combine("FallPlataformPB", "PF_Player01"), spawnPos[Random.Range(0, spawnPos.Length)].GetComponent<Transform>().position, Quaternion.identity, 0, new object[] { pv.ViewID });
                break;
            case 2:
                controller = PhotonNetwork.Instantiate(Path.Combine("FallPlataformPB", "PF_Player02"), spawnPos[Random.Range(0, spawnPos.Length)].GetComponent<Transform>().position, Quaternion.identity, 0, new object[] { pv.ViewID });
                break;
            case 3:
                controller = PhotonNetwork.Instantiate(Path.Combine("FallPlataformPB", "PF_Player03"), spawnPos[Random.Range(0, spawnPos.Length)].GetComponent<Transform>().position, Quaternion.identity, 0, new object[] { pv.ViewID });
                break;
            case 4:
                controller = PhotonNetwork.Instantiate(Path.Combine("FallPlataformPB", "PF_Player04"), spawnPos[Random.Range(0, spawnPos.Length)].GetComponent<Transform>().position, Quaternion.identity, 0, new object[] { pv.ViewID });
                break;
            case 5:
                controller = PhotonNetwork.Instantiate(Path.Combine("FallPlataformPB", "PF_Player05"), spawnPos[Random.Range(0, spawnPos.Length)].GetComponent<Transform>().position, Quaternion.identity, 0, new object[] { pv.ViewID });
                break;
            case 6:
                controller = PhotonNetwork.Instantiate(Path.Combine("FallPlataformPB", "PF_Player06"), spawnPos[Random.Range(0, spawnPos.Length)].GetComponent<Transform>().position, Quaternion.identity, 0, new object[] { pv.ViewID });
                break;
        }
    }

}
