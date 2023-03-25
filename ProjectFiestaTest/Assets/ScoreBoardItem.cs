using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class ScoreBoardItem : MonoBehaviourPunCallbacks
{
    public TMP_Text userNameTxt, killsTXT, deathTXT;
    Player player;

    public void Initialized(Player player)
    {
        this.player = player;
        userNameTxt.text = player.NickName;
        UpdateStats();
    }

    void UpdateStats()
    {
        if(player.CustomProperties.TryGetValue("kills", out object kills))
        {
            killsTXT.text = kills.ToString();
        }

        if (player.CustomProperties.TryGetValue("deaths", out object deaths))
        {
            deathTXT.text = deaths.ToString();
        }
    }


    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        if(targetPlayer == player)
        {
            if (changedProps.ContainsKey("kills") || changedProps.ContainsKey("deaths"))
            {
                UpdateStats();
            }
        }
    }
}
