using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayer : MonoBehaviour
{
    
    [SerializeField] Transform[] positions;
    
    void Start()
    {
        if (PlayerSettings.Instance.characterID == 1) PhotonNetwork.Instantiate("PlayerRed", positions[0].position, Quaternion.Euler(0, 180, 0));
        if (PlayerSettings.Instance.characterID == 2) PhotonNetwork.Instantiate("PlayerBlue", positions[1].position, Quaternion.Euler(0, 180, 0));
        if (PlayerSettings.Instance.characterID == 3) PhotonNetwork.Instantiate("PlayerGreen", positions[2].position, Quaternion.Euler(0, 180, 0));
        if (PlayerSettings.Instance.characterID == 4) PhotonNetwork.Instantiate("PlayerYellow", positions[3].position, Quaternion.Euler(0, 180, 0));
        if (PlayerSettings.Instance.characterID == 5) PhotonNetwork.Instantiate("PlayerPurple", positions[4].position, Quaternion.Euler(0, 180, 0));
        if (PlayerSettings.Instance.characterID == 6) PhotonNetwork.Instantiate("PlayerPink", positions[5].position, Quaternion.Euler(0, 180, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
