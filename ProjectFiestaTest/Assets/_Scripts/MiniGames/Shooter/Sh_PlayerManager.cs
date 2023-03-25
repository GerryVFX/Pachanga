using System.IO;
using System.Collections;
using System.Linq;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class Sh_PlayerManager : MonoBehaviour
{
    PhotonView pv;
    GameObject controller;
    GameObject[] spawnPos;
    

    int kills;
    int deaths;
    public float timeOff = 0;
    bool gameStart;

    private void Awake()
    {
        pv = GetComponent<PhotonView>();
        spawnPos = GameObject.FindGameObjectsWithTag("SpawnPos");    
    }

    void Start()
    {
        if (pv.IsMine) CreateControll();
        gameStart = true;
    }

    //private void Update()
    //{
    //    if (timeOff < 10 && gameStart)
    //    {
    //        timeOff += Time.deltaTime;
    //    }
    //    else if(timeOff > 10)
    //    {
    //        timeOff = 0;
    //        gameStart = false;
    //        Close.Instance.OpenPanel();
    //    }
    //}
    void CreateControll()
    {
        switch (PlayerSettings.Instance.characterID)
        {
            case 0:
                controller = PhotonNetwork.Instantiate(Path.Combine("ShooterPB", "Player00"), spawnPos[Random.Range(0, spawnPos.Length)].GetComponent<Transform>().position, Quaternion.identity, 0, new object[] {pv.ViewID});
                break;
            case 1:
                controller = PhotonNetwork.Instantiate(Path.Combine("ShooterPB", "Player01"), spawnPos[Random.Range(0, spawnPos.Length)].GetComponent<Transform>().position, Quaternion.identity, 0, new object[] { pv.ViewID });
                break;
            case 2:
                controller = PhotonNetwork.Instantiate(Path.Combine("ShooterPB", "Player02"), spawnPos[Random.Range(0, spawnPos.Length)].GetComponent<Transform>().position, Quaternion.identity, 0, new object[] { pv.ViewID });
                break;
            case 3:
                controller = PhotonNetwork.Instantiate(Path.Combine("ShooterPB", "Player03"), spawnPos[Random.Range(0, spawnPos.Length)].GetComponent<Transform>().position, Quaternion.identity, 0, new object[] { pv.ViewID });
                break;
            case 4:
                controller = PhotonNetwork.Instantiate(Path.Combine("ShooterPB", "Player04"), spawnPos[Random.Range(0, spawnPos.Length)].GetComponent<Transform>().position, Quaternion.identity, 0, new object[] { pv.ViewID });
                break;
            case 5:
                controller = PhotonNetwork.Instantiate(Path.Combine("ShooterPB", "Player05"), spawnPos[Random.Range(0, spawnPos.Length)].GetComponent<Transform>().position, Quaternion.identity, 0, new object[] { pv.ViewID });
                break;
            case 6:
                controller = PhotonNetwork.Instantiate(Path.Combine("ShooterPB", "Player06"), spawnPos[Random.Range(0, spawnPos.Length)].GetComponent<Transform>().position, Quaternion.identity, 0, new object[] { pv.ViewID });
                break;
        }
    }

    public void Die()
    {
        PhotonNetwork.Destroy(controller);
        CreateControll();

        deaths++;

        Hashtable hash = new Hashtable();
        hash.Add("deaths", deaths);
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
    }

    public void GetKills()
    {
        pv.RPC(nameof(RPC_GetKill), pv.Owner);
    }

    [PunRPC]
    void RPC_GetKill()
    {
        kills++;

        Hashtable hash = new Hashtable();
        hash.Add("kills", kills);
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
    }

    public static Sh_PlayerManager find(Player player)
    {
        return FindObjectsOfType<Sh_PlayerManager>().SingleOrDefault(x => x.pv.Owner == player);

    }
}
