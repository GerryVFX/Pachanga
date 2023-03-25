using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class PlayerNameManager : MonoBehaviour
{
    [SerializeField] TMP_InputField userImput;

    private void Start()
    {
        if (PlayerPrefs.HasKey("username"))
        {
            userImput.text = PlayerPrefs.GetString("username");
            PhotonNetwork.NickName = PlayerPrefs.GetString("username");
        }
        else
        {
            userImput.text = "Player " + Random.Range(0, 10000).ToString("0000");
            OnUserNameValueChanged();
        }
    }
    public void OnUserNameValueChanged()
    {
        PhotonNetwork.NickName = userImput.text;
        PlayerPrefs.SetString("username", userImput.text);
    }
}
