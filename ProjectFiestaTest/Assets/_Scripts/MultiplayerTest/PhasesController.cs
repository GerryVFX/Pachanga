using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhasesController : MonoBehaviourPunCallbacks
{
    public static PhasesController Instance;

    public List<GameObject> playerOrder = new List<GameObject>();

    private void Awake()
    {
        if(Instance == null && PhotonNetwork.IsMasterClient)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
