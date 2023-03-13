using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerProp : MonoBehaviour
{
    public int turnOrder;

    void Start()
    {
        if (PhotonNetwork.IsMasterClient == false)
        {
            return;
        }
        PhasesController.Instance.playerOrder.Add(gameObject);
        turnOrder = PhasesController.Instance.playerOrder.IndexOf(gameObject);
    }
}
